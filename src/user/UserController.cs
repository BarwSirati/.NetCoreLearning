using FoodPool.user.dto;
using FoodPool.user.entities;
using FoodPool.user.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FoodPool.user;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserService userService, ILogger<UserController> logger)
    {
        this._userService = userService;
        this._logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetUserDto>>> GetAll()
    {
        return Ok(await this._userService.GetAll());
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<ActionResult<GetUserDto>> GetById(int id)
    {
        return Ok(await this._userService.GetById(id));
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<GetUserDto>> Update(UpdateUserDto updateUserDto, int id)
    {
        return Ok(await this._userService.Update(updateUserDto, id));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<GetUserDto>> Delete(int id)
    {
        return Ok(await this._userService.Delete(id));
    }
}