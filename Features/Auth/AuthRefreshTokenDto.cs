using System.ComponentModel.DataAnnotations;

namespace VehicleHistory.Features.Auth;

public class AuthRefreshTokenDto
{
    [Required]
    public string RefreshToken { get; set; } = string.Empty;
}