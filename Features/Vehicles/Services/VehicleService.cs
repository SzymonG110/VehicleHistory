using Microsoft.EntityFrameworkCore;
using VehicleHistory.Data;
using VehicleHistory.Features.Vehicles.Dtos;
using VehicleHistory.Features.Vehicles.Models;

namespace VehicleHistory.Features.Vehicles.Services;

public class VehicleService(VehicleHistoryDbContext dbContext) : IVehicleService
{
    public async Task<IEnumerable<VehicleResponseDto>> GetUserVehiclesAsync(Guid userId)
    {
        var vehicles = await dbContext.Vehicles
            .Where(v => v.UserId == userId)
            .Select(v => new VehicleResponseDto
            {
                Id = v.Id,
                Brand = v.Brand,
                Model = v.Model,
                Year = v.Year,
                UserId = v.UserId
            })
            .ToListAsync();

        return vehicles;
    }

    public async Task<VehicleResponseDto?> GetVehicleByIdAsync(Guid vehicleId, Guid userId)
    {
        var vehicle = await dbContext.Vehicles
            .Where(v => v.Id == vehicleId && v.UserId == userId)
            .Select(v => new VehicleResponseDto
            {
                Id = v.Id,
                Brand = v.Brand,
                Model = v.Model,
                Year = v.Year,
                UserId = v.UserId
            })
            .FirstOrDefaultAsync();

        return vehicle;
    }

    public async Task<VehicleResponseDto?> CreateVehicleAsync(VehicleDto vehicleDto, Guid userId)
    {
        var vehicle = new Vehicle
        {
            Id = Guid.NewGuid(),
            Brand = vehicleDto.Brand,
            Model = vehicleDto.Model,
            Year = vehicleDto.Year,
            UserId = userId
        };

        dbContext.Vehicles.Add(vehicle);
        await dbContext.SaveChangesAsync();

        return new VehicleResponseDto
        {
            Id = vehicle.Id,
            Brand = vehicle.Brand,
            Model = vehicle.Model,
            Year = vehicle.Year,
            UserId = vehicle.UserId
        };
    }

    public async Task<VehicleResponseDto?> UpdateVehicleAsync(Guid vehicleId, VehicleDto vehicleDto, Guid userId)
    {
        var vehicle = await dbContext.Vehicles
            .FirstOrDefaultAsync(v => v.Id == vehicleId && v.UserId == userId);

        if (vehicle == null)
        {
            return null;
        }

        vehicle.Brand = vehicleDto.Brand;
        vehicle.Model = vehicleDto.Model;
        vehicle.Year = vehicleDto.Year;

        dbContext.Vehicles.Update(vehicle);
        await dbContext.SaveChangesAsync();

        return new VehicleResponseDto
        {
            Id = vehicle.Id,
            Brand = vehicle.Brand,
            Model = vehicle.Model,
            Year = vehicle.Year,
            UserId = vehicle.UserId
        };
    }

    public async Task<bool> DeleteVehicleAsync(Guid vehicleId, Guid userId)
    {
        var vehicle = await dbContext.Vehicles
            .FirstOrDefaultAsync(v => v.Id == vehicleId && v.UserId == userId);

        if (vehicle == null)
        {
            return false;
        }

        dbContext.Vehicles.Remove(vehicle);
        await dbContext.SaveChangesAsync();

        return true;
    }
}
