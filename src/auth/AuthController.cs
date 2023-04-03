using AutoMapper;
using FoodPool.auth.dto;
using FoodPool.auth.interfaces;
using FoodPool.user.dto;
using FoodPool.user.entities;
using FoodPool.user.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodPool.auth;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;
    private readonly IMapper _mapper;

    public AuthController(IMapper mapper, IUserRepository userRepository,
        IAuthService authService, ILogger<AuthController> logger)
    {
        _authService = authService;
        _logger = logger;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public ActionResult<GetUserDto> Register(CreateUserDto createUserDto)
    {
        try
        {
            if (_userRepository.Exist(createUserDto.Username!))
                return Conflict();


            var user = _mapper.Map<UserEntity>(createUserDto);
            _userRepository.Insert(user);
            _userRepository.Save();
            var mapUser = _mapper.Map<GetUserDto>(user);
            return Ok(mapUser);
        }
        catch (Exception)
        {
            return BadRequest();
        }
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