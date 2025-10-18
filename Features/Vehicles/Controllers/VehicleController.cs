using Microsoft.AspNetCore.Mvc;
using VehicleHistory.Features.Auth.Base;
using VehicleHistory.Features.Vehicles.Dtos;
using VehicleHistory.Features.Vehicles.Services;

namespace VehicleHistory.Features.Vehicles.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehicleController(IVehicleService vehicleService) : AuthorizedControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var userId = GetUserId();
        var vehicles = await vehicleService.GetUserVehiclesAsync(userId);
        return Ok(vehicles);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var userId = GetUserId();
        var vehicle = await vehicleService.GetVehicleByIdAsync(id, userId);
        
        if (vehicle == null)
        {
            return NotFound();
        }
        
        return Ok(vehicle);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] VehicleDto vehicleDto)
    {
        var userId = GetUserId();
        var vehicle = await vehicleService.CreateVehicleAsync(vehicleDto, userId);
        
        if (vehicle == null)
        {
            return BadRequest("Failed to create vehicle");
        }
        
        return Ok(vehicle);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Guid id, [FromBody] VehicleDto vehicleDto)
    {
        var userId = GetUserId();
        var vehicle = await vehicleService.UpdateVehicleAsync(id, vehicleDto, userId);
        
        if (vehicle == null)
        {
            return NotFound();
        }
        
        return Ok(vehicle);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var userId = GetUserId();
        var success = await vehicleService.DeleteVehicleAsync(id, userId);
        
        if (!success)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
