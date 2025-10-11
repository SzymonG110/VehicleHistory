using Microsoft.EntityFrameworkCore;
using VehicleHistory.Features.Users;
using VehicleHistory.Features.Vehicles;

namespace VehicleHistory.Data;

public class VehicleHistoryDbContext(DbContextOptions<VehicleHistoryDbContext> options): DbContext(options)
{
    public DbSet<Vehicle> Vehicles { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
}