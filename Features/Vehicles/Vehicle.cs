using System.ComponentModel.DataAnnotations.Schema;

namespace VehicleHistory.Features.Vehicles;

[Table("vehicles")]
public class Vehicle
{
    public Guid Id { get; set; }
    public String Brand { get; set; } = String.Empty;
    public String Model { get; set; } = String.Empty;
    public int Year { get; set; } = 0;
}