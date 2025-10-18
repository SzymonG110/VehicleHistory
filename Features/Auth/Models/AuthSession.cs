using VehicleHistory.Features.Users.Models;

namespace VehicleHistory.Features.Auth.Models;

public class AuthSession
{
    public Guid Id { get; set; }
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime Expires { get; set; }
    public string Ip { get; set; } = string.Empty;
    public string Device { get; set; } = string.Empty;
    
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
}