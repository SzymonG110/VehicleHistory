namespace VehicleHistory.Features.Auth;

public interface IAuthService
{
    Task<AuthTokens?> RegisterAsync(AuthRegisterDto data, AuthDeviceData deviceData);
    Task<AuthTokens?> LoginAsync(AuthLoginDto data, AuthDeviceData deviceData);
}