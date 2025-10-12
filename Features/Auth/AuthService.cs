using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VehicleHistory.Data;
using VehicleHistory.Features.Users;

namespace VehicleHistory.Features.Auth;

public class AuthService(VehicleHistoryDbContext dbContext, IConfiguration configuration) : IAuthService
{
    private readonly int ACCESS_TOKEN_EXPIRATION_IN_MINUTES = 3;
    private readonly int REFRESH_TOKEN_EXPIRATION_IN_DAYS = 7;
    
    public async Task<AuthTokens?> RegisterAsync(AuthRegisterDto data, AuthDeviceData deviceData)
    {
        var isUser = await dbContext.Users.FirstOrDefaultAsync(user => user.Email == data.Email) != null;
        if (isUser)
        {
            return null;
        }
        
        if (data.Password != data.ConfirmPassword)
        {
            return null;
        }

        User user = new();
        var hashedPassword = new PasswordHasher<User>().HashPassword(user, data.Password);
        
        user.Email = data.Email;
        user.Name = data.Name;
        user.Password = hashedPassword;
        user.Surname = data.Surname;
        
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
        
        var token = CreateTokens(user);
        
        await CreateSession(user.Id, deviceData, token);
        
        return token;
    }

    public async Task<AuthTokens?> LoginAsync(AuthLoginDto data, AuthDeviceData deviceData)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(user => user.Email == data.Email);
        if (user == null || new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, data.Password) == PasswordVerificationResult.Failed)
        {
            return null;
        }
        
        var token = CreateTokens(user);
        
        await CreateSession(user.Id, deviceData, token);
        
        return token;
    }

    public async Task<AuthTokens?> RefreshTokenAsync(string refreshToken)
    {
        var session = dbContext.AuthSessions.FirstOrDefault(session => session.RefreshToken == refreshToken);
        if (session == null || session.Expires < DateTime.UtcNow)
        {
            return null;
        }
        
        var user = dbContext.Users.FirstOrDefault(user => user.Id == session.UserId);
        if (user == null)
        {
            return null;
        }

        var tokens = CreateTokens(user);
        
        session.RefreshToken = tokens.RefreshToken;
        session.Expires = DateTime.UtcNow.AddDays(this.REFRESH_TOKEN_EXPIRATION_IN_DAYS);
        
        dbContext.AuthSessions.Update(session);
        await dbContext.SaveChangesAsync();
        
        return tokens;
    }

    private AuthTokens CreateTokens(User user)
    {
        var tokens = new AuthTokens
        {
            AccessToken = CreateToken(user),
            RefreshToken = CreateRefreshToken()
        };
        
        return tokens;
    }

    private string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var tokenDescriptor = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(this.ACCESS_TOKEN_EXPIRATION_IN_MINUTES),
            signingCredentials: credentials
        );
        
        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }

    private string CreateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
    
    private async Task CreateSession(Guid userId, AuthDeviceData deviceData, AuthTokens tokens)
    {
        var refreshTokenExpires = DateTime.UtcNow.AddDays(this.REFRESH_TOKEN_EXPIRATION_IN_DAYS);

        var authSession = new AuthSession
        {
            UserId = userId,
            RefreshToken = tokens.RefreshToken,
            Expires = refreshTokenExpires,
            Ip = deviceData.Ip,
            Device = deviceData.Device
        };
        
        dbContext.AuthSessions.Add(authSession);
        await dbContext.SaveChangesAsync();
    }
}