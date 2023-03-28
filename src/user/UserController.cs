using FoodPool.share.types;
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

    public UserController(IUserService userService,IConfiguration configuration)
    {
        this._userService = userService;
        this._configuration = configuration;
    }

    [HttpGet]
    public async Task<ActionResult<Response<List<GetUserDto>>>> GetAll()
    {
        return Ok(await this._userService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Response<GetUserDto>>> GetById(int id)
    {
        return Ok(await this._userService.GetById(id));
    }

    [HttpPost]
    public async Task<ActionResult<Response<GetUserDto>>> Create(CreateUserDto createUserDto)
    {
        return Ok(await this._userService.Create(createUserDto));
    }
}