using System.ComponentModel.DataAnnotations.Schema;
using VehicleHistory.Features.Auth;

namespace VehicleHistory.Features.Users;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    
    public ICollection<AuthSession> AuthSessions { get; set; } = new List<AuthSession>(); 
}