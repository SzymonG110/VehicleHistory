using Microsoft.EntityFrameworkCore;
using VehicleHistory.Features.Vehicles;

namespace VehicleHistory.Data;

public class VehicleHistoryDbContext(DbContextOptions<VehicleHistoryDbContext> options): DbContext(options)
{
    public DbSet<Vehicle> Vehicles { get; set; } = null!;
}