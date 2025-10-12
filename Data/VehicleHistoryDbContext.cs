using Microsoft.EntityFrameworkCore;
using VehicleHistory.Features.Auth;
using VehicleHistory.Features.Users;
using VehicleHistory.Features.Vehicles;

namespace VehicleHistory.Data;

public class VehicleHistoryDbContext(DbContextOptions<VehicleHistoryDbContext> options): DbContext(options)
{
    public DbSet<Vehicle> Vehicles { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<AuthSession> AuthSessions { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AuthSession>()
            .HasOne(c => c.User)
            .WithMany(p => p.AuthSessions)
            .HasForeignKey(c => c.UserId)
            .IsRequired();

        base.OnModelCreating(modelBuilder);
    }
}