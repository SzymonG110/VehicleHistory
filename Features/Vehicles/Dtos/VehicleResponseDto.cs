namespace VehicleHistory.Features.Vehicles.Dtos;

public class VehicleResponseDto
{
    public Guid Id { get; set; }
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; }
    public Guid UserId { get; set; }
}
