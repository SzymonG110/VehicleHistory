namespace VehicleHistory.Features.Auth;

public class AuthTokensDto
{
    public string accessToken { get; set; } = string.Empty;
    public string refreshToken { get; set; } = string.Empty;
}