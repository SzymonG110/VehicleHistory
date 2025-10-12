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
        var token = await authService.RegisterAsync(data, deviceData);
        
        if (token == null)
        {
            return BadRequest("User already exists or passwords do not match");    
        }
        
        return Ok(token);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthLoginDto data)
    {
        var deviceData = this.GenerateDeviceData();
        var token = await authService.LoginAsync(data, deviceData);
        
        if (token == null)
        {
            return BadRequest("Invalid credentials");
        }
        
        return Ok(token);
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
