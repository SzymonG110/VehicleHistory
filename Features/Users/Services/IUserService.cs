using VehicleHistory.Features.Users.Dtos;

namespace VehicleHistory.Features.Users.Services;

public interface IUserService
{
    Task<UserDto> GetUser(Guid userId);
}