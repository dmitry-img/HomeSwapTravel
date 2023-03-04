using HomeSwapTravel.Application.Common.Interfaces.Identity;
using HomeSwapTravel.Application.Common.Models;
using HomeSwapTravel.Application.Common.Responses;
using HomeSwapTravel.WebUI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class AuthController : ApiControllerBase
{
    private readonly IAuthService _authenticationService;
    public AuthController(IAuthService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("Login")]
    public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
    {
        return Ok(await _authenticationService.Login(request));
    }

    [HttpPost("Register")]
    public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
    {
        return Ok(await _authenticationService.Register(request));
    }
}

