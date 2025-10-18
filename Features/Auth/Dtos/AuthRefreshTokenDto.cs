using System.ComponentModel.DataAnnotations;

namespace VehicleHistory.Features.Auth.Dtos;

public class AuthRefreshTokenDto
{
    [Required]
    public string RefreshToken { get; set; } = string.Empty;
}