using FoodPool.user.dto;
using FoodPool.user.entities;
using FoodPool.user.interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FoodPool.user;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IConfiguration _configuration;
    private readonly ILogger<UserController> _logger;
    public UserController(IUserService userService,IConfiguration configuration,ILogger<UserController> logger)
    {
        this._userService = userService;
        this._configuration = configuration;
        this._logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetUserDto>>> GetAll()
    {
        return Ok(await this._userService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetUserDto>> GetById(int id)
    {
        return Ok(await this._userService.GetById(id));
    }

    [HttpPost]
    public async Task<ActionResult<GetUserDto>> Create(CreateUserDto createUserDto)
    {
        return Ok(await this._userService.Create(createUserDto));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<GetUserDto>> Update(UpdateUserDto updateUserDto,int id)
    {
        return Ok(await this._userService.Update(updateUserDto,id));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<GetUserDto>> Delete(int id)
    {
        return Ok(await this._userService.Delete(id));
    }
}