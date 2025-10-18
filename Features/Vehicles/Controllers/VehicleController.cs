using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VehicleHistory.Data;
using VehicleHistory.Features.Auth.Base;
using VehicleHistory.Features.Vehicles.Dtos;
using VehicleHistory.Features.Vehicles.Models;

namespace VehicleHistory.Features.Vehicles.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehicleController(VehicleHistoryDbContext dbContext, IMapper mapper) : AuthorizedControllerBase
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
