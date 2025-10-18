using System.ComponentModel.DataAnnotations;

namespace VehicleHistory.Features.Vehicles.Dtos;

public class VehicleDto
{
    [Required]
    [StringLength(50)]
    public String Brand { get; set; } = String.Empty;
    
    [Required]
    [StringLength(50)]
    public String Model { get; set; } = String.Empty;
    
    [Required]
    [Range(1950, 2100)]
    public int Year { get; set; } = 0;
}