using VehicleHistory.Features.Vehicles.Dtos;

namespace VehicleHistory.Features.Vehicles.Services;

public interface IVehicleService
{
    Task<IEnumerable<VehicleResponseDto>> GetUserVehiclesAsync(Guid userId);
    Task<VehicleResponseDto?> GetVehicleByIdAsync(Guid vehicleId, Guid userId);
    Task<VehicleResponseDto?> CreateVehicleAsync(VehicleDto vehicleDto, Guid userId);
    Task<VehicleResponseDto?> UpdateVehicleAsync(Guid vehicleId, VehicleDto vehicleDto, Guid userId);
    Task<bool> DeleteVehicleAsync(Guid vehicleId, Guid userId);
}
