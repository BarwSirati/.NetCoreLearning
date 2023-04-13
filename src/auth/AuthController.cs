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
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;
    private readonly IUserService _userService;

    public AuthController(
        IAuthService authService, ILogger<AuthController> logger, IUserService userService)
    {
        _userService = userService;
        _authService = authService;
        _logger = logger;
    }

    [HttpPost("register")]
    public ActionResult<GetUserDto> Register(CreateUserDto createUserDto)
    {
        var user = _userService.Create(createUserDto);
        if (user.IsFailed) return BadRequest();

        return Ok(user.Value);
    }

    [HttpPost("login")]
    public async Task<ActionResult<JwtDto>> Login(AuthDto authDto)
    {
        var result = await _authService.Login(authDto);
        if (result.IsFailed) return BadRequest(result.Errors);

        return Ok(result.Value);
    }
}