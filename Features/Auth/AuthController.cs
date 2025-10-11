using Microsoft.AspNetCore.Mvc;

namespace VehicleHistory.Features.Auth;

[Route("api/[controller]")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] AuthRegisterDto data)
    {
        var token = await authService.RegisterAsync(data);
        return Ok(token);
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] AuthLoginDto data)
    {
        var token = await authService.LoginAsync(data);
        return Ok(token);
    }
}
