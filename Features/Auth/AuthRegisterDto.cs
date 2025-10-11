using System.ComponentModel.DataAnnotations;

namespace VehicleHistory.Features.Auth;

public class AuthRegisterDto
{
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    [StringLength(50)]
    public string Surname { get; set; } = string.Empty;
    
    [Required]
    [StringLength(50)]
    public string Email { get; set; } = string.Empty;
    
    [Required]
    [StringLength(50)]
    public string Password { get; set; } = string.Empty;
    
    [Required]
    [StringLength(50)]
    public string ConfirmPassword { get; set; } = string.Empty;
}