using VehicleHistory.Features.Auth.Models;
using VehicleHistory.Features.Vehicles.Models;

namespace VehicleHistory.Features.Users.Models;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    
    public ICollection<AuthSession> AuthSessions { get; set; } = new List<AuthSession>();
    public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}