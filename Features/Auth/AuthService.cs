using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VehicleHistory.Data;
using VehicleHistory.Features.Users;

namespace VehicleHistory.Features.Auth;

public class AuthService(VehicleHistoryDbContext dbContext, IConfiguration configuration) : IAuthService
{
    public async Task<string?> RegisterAsync(AuthRegisterDto data)
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
        
        return CreateToken(user);
    }

    public async Task<string?> LoginAsync(AuthLoginDto data)
    {
        throw new NotImplementedException();
    }

    private string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, "test")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var tokenDescriptor = new JwtSecurityToken(
            issuer: configuration["Jwt:Issuer"],
            audience: configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: credentials
        );
        
        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}