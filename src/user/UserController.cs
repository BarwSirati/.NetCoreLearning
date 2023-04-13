using FoodPool.provider.interfaces;
using FoodPool.user.dto;
using FoodPool.user.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodPool.user;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IHttpContextProvider _contextProvider;
    private readonly IUserService _userService;

    public UserController(IHttpContextProvider provider, IUserService userService)
    {
        _userService = userService;
        _contextProvider = provider;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetUserDto>>> GetAll()
    {
        var users = await _userService.GetAll();
        return users;
    }

    [HttpGet("current")]
    [Authorize]
    public async Task<ActionResult<GetUserDto>> GetCurrent()
    {
        var user = await _userService.GetById(_contextProvider.GetCurrentUser());
        return user;
    }

    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<ActionResult<GetUserDto>> GetById(int id)
    {
        if (_contextProvider.GetCurrentUser() != id) return Unauthorized();
        var user = await _userService.GetById(id);
        return user;
    }

    [HttpPut("{id:int}")]
    [Authorize]
    public ActionResult<GetUserDto> Update(UpdateUserDto updateUserDto, int id)
    {
        if (_contextProvider.GetCurrentUser() != id) return Unauthorized();
        var user = _userService.Update(updateUserDto, id);
        if (user.Result.IsFailed) return BadRequest();
        return user.Result.Value;
    }

    [HttpDelete("{id:int}")]
    [Authorize]
    public ActionResult Delete(int id)
    {
        if (_contextProvider.GetCurrentUser() != id) return Unauthorized();
        var user = _userService.Delete(id);
        if (user.IsFailed) return BadRequest();
        return Ok();
    }
}