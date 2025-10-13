using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleHistory.Data;

namespace VehicleHistory.Features.Vehicles;

[Route("api/[controller]")]
[ApiController]
public class VehicleController(VehicleHistoryDbContext dbContext, IMapper mapper) : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        var vehicles = dbContext.Vehicles.ToList();
        return Ok(vehicles);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Post([FromBody] VehicleDto vehicle)
    {
        var vehicleEntity = mapper.Map<Vehicle>(vehicle);
        dbContext.Vehicles.Add(vehicleEntity);
        await dbContext.SaveChangesAsync();
        return Ok(vehicleEntity);
    }
}
