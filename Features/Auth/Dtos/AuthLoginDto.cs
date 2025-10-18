using System.ComponentModel.DataAnnotations;

namespace VehicleHistory.Features.Auth.Dtos;

public class AuthLoginDto
{
    [Required]
    [StringLength(50)]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [StringLength(50)]
    public string Password { get; set; } = string.Empty;
}