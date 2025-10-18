using VehicleHistory.Features.Users.Models;

namespace VehicleHistory.Features.Vehicles.Models;

public class Vehicle
{
    public Guid Id { get; set; }
    public String Brand { get; set; } = String.Empty;
    public String Model { get; set; } = String.Empty;
    public int Year { get; set; } = 0;
    
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
}