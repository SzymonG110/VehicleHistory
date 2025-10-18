using Microsoft.EntityFrameworkCore;
using VehicleHistory.Features.Auth.Models;
using VehicleHistory.Features.Users.Models;
using VehicleHistory.Features.Vehicles.Models;

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

        modelBuilder.Entity<Vehicle>()
            .HasOne(v => v.User)
            .WithMany(u => u.Vehicles)
            .HasForeignKey(v => v.UserId)
            .IsRequired();

        base.OnModelCreating(modelBuilder);
    }
}