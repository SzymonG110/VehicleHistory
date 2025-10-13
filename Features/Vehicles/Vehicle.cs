namespace VehicleHistory.Features.Vehicles;

public class Vehicle
{
    public Guid Id { get; set; }
    public String Brand { get; set; } = String.Empty;
    public String Model { get; set; } = String.Empty;
    public int Year { get; set; } = 0;
}