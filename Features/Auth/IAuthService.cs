namespace VehicleHistory.Features.Auth;

public interface IAuthService
{
    Task<string?> RegisterAsync(AuthRegisterDto data);
    Task<string?> LoginAsync(AuthLoginDto data);
}