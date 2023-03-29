using System.Net;
using FoodPool.auth.dto;
using FoodPool.auth.interfaces;
using FoodPool.user.dto;
using FoodPool.user.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodPool.auth;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IUserService userService, IAuthService authService, ILogger<AuthController> logger)
    {
        _userService = userService;
        _authService = authService;
        _logger = logger;
    }

    [HttpPost("register")]
    public async Task<ActionResult<GetUserDto>> Register(CreateUserDto createUserDto)
    {
        return Ok(await _userService.Create(createUserDto));
    }

    [HttpPost("login")]
    public async Task<ActionResult<JwtDto>> Login(AuthDto authDto)
    {
        var result = await _authService.Login(authDto);
        if (result.IsFailed)
        {
            return BadRequest(result.Errors);
        }

        return Ok(result.Value);
    }
}