using VehicleHistory.Features.Auth.Dtos;
using VehicleHistory.Features.Auth.Models;

namespace VehicleHistory.Features.Auth.Services;

public interface IAuthService
{
    Task<AuthTokens?> RegisterAsync(AuthRegisterDto data, AuthDeviceData deviceData);
    Task<AuthTokens?> LoginAsync(AuthLoginDto data, AuthDeviceData deviceData);
    Task<AuthTokens?> RefreshTokenAsync(string refreshToken);
}