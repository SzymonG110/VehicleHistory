using Microsoft.EntityFrameworkCore;
using VehicleHistory.Data;
using VehicleHistory.Features.Users.Dtos;

namespace VehicleHistory.Features.Users.Services;

public class UserService(VehicleHistoryDbContext dbContext) : IUserService
{
    public async Task<UserDto> GetUser(Guid userId)
    {
        var user = await dbContext.Users.FirstOrDefaultAsync(user => user.Id == userId);
        if (user == null)
        {
            return null;
        }

        return new UserDto { Id = user.Id, Email = user.Email, Name = user.Name, Surname = user.Surname };
    }
}