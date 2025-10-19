using Microsoft.AspNetCore.Mvc;
using VehicleHistory.Features.Auth.Base;
using VehicleHistory.Features.Users.Dtos;
using VehicleHistory.Features.Users.Services;

namespace VehicleHistory.Features.Users.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService userService) : AuthorizedControllerBase
{
    
    [HttpGet("me")]
    public async Task<IActionResult> Me()
    {
        var userId = GetUserId();
        var user = await userService.GetUser(userId);
        
        if (user == null)
        {
            return NotFound("User not found");
        }
        
        return Ok(user);
    }
}
