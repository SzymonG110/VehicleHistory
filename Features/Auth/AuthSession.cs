using VehicleHistory.Features.Users;

namespace VehicleHistory.Features.Auth;

public class AuthSession
{
    public string RefreshToken { get; set; } = string.Empty;
    public DateTime Expires { get; set; }
    public string Ip { get; set; } = string.Empty;
    public string Device { get; set; } = string.Empty;
    
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
}