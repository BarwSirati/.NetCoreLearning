using FoodPool.share.types;
using FoodPool.user.dto;
using FoodPool.user.entities;
using FoodPool.user.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodPool.user;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        this._userService = userService;
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
    public ActionResult<UserEntity?> Create(UserEntity userEntity)
    {
        return this._userService.Create(userEntity);
    }
}