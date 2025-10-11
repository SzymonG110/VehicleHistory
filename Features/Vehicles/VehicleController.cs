using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VehicleHistory.Data;

namespace VehicleHistory.Features.Vehicles;

[Route("api/[controller]")]
[ApiController]
public class VehicleController(VehicleHistoryDbContext dbContext, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var vehicles = dbContext.Vehicles.ToList();
        return Ok(vehicles);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] VehicleDto vehicle)
    {
        var vehicleEntity = mapper.Map<Vehicle>(vehicle);
        dbContext.Vehicles.Add(vehicleEntity);
        await dbContext.SaveChangesAsync();
        return Ok(vehicleEntity);
    }
}
