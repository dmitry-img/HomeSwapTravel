using HomeSwapTravel.Application.Common.Models;
using HomeSwapTravel.Application.Common.Responses;

namespace HomeSwapTravel.Application.Common.Interfaces.Identity;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<RegistrationResponse> Register(RegistrationRequest request);
}

