namespace VehicleHistory.Features.Auth;

public interface IAuthService
{
    Task<AuthTokensDto?> RegisterAsync(AuthRegisterDto data);
    Task<AuthTokensDto?> LoginAsync(AuthLoginDto data);
}