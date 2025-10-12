using Microsoft.AspNetCore.Mvc;
using UAParser;

namespace VehicleHistory.Features.Auth;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    private readonly Parser _uaParser = Parser.GetDefault();
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] AuthRegisterDto data)
    {
        var deviceData = this.GenerateDeviceData();
        var tokens = await authService.RegisterAsync(data, deviceData);
        
        if (tokens == null)
        {
            return BadRequest("User already exists or passwords do not match");    
        }
        
        return Ok(tokens);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthLoginDto data)
    {
        var deviceData = this.GenerateDeviceData();
        var tokens = await authService.LoginAsync(data, deviceData);
        
        if (tokens == null)
        {
            return BadRequest("Invalid credentials");
        }
        
        return Ok(tokens);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken([FromBody] AuthRefreshTokenDto data)
    {
        var tokens = await authService.RefreshTokenAsync(data.RefreshToken);
        
        if (tokens == null)
        {
            return BadRequest("Invalid refresh token");
        }
        
        return Ok(tokens);
    }

    private AuthDeviceData GenerateDeviceData()
    {
        var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
        var userAgentString = HttpContext.Request.Headers["User-Agent"].ToString();
        
        var clientInfo = _uaParser.Parse(userAgentString);
        var deviceDescription = $"{clientInfo.Device.Family} ({clientInfo.OS.Family})";

        var deviceData = new AuthDeviceData
        {
            Ip = ip ?? "<not available>",
            Device = deviceDescription
        };
        
        return deviceData;  
    }
}
