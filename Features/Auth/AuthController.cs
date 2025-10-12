using Microsoft.AspNetCore.Mvc;

namespace VehicleHistory.Features.Auth;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] AuthRegisterDto data)
    {
        var token = await authService.RegisterAsync(data);
        if (token == null)
        {
            return BadRequest("User already exists or passwords do not match");    
        }
        
        return Ok(token);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthLoginDto data)
    {
        var token = await authService.LoginAsync(data);
        if (token == null)
        {
            return BadRequest("Invalid credentials");
        }
        
        return Ok(token);
    }
}
