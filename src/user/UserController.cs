using AutoMapper;
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
    private readonly IUserRepository _userRepository;
    private readonly IHttpContextProvider _contextProvider;
    private readonly IMapper _mapper;

    public UserController(IMapper mapper, IUserRepository userRepository, IHttpContextProvider provider)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _contextProvider = provider;
    }

    [HttpGet]
    public ActionResult<List<GetUserDto>> GetAll()
    {
        try
        {
            var users = _userRepository.GetAll();
            return Ok(users.Select(c => _mapper.Map<GetUserDto>(c)).ToList());
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet("{id:int}")]
    [Authorize]
    public ActionResult<GetUserDto> GetById(int id)
    {
        try
        {
            if (_contextProvider.GetCurrentUser() != id)
                return Unauthorized();

            var user = _userRepository.GetById(id);
            return Ok(_mapper.Map<GetUserDto>(user));
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }


    [HttpPut("{id:int}")]
    [Authorize]
    public ActionResult<GetUserDto> Update(UpdateUserDto updateUserDto, int id)
    {
        try
        {
            if (_contextProvider.GetCurrentUser() != id)
                return Unauthorized();
            _userRepository.Update(updateUserDto, id);
            _userRepository.Save();
            var user = _userRepository.GetById(id);
            return Ok(_mapper.Map<GetUserDto>(user));
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult Delete(int id)
    {
        try
        {
            if (_contextProvider.GetCurrentUser() != id)
                return Unauthorized();
            _userRepository.Delete(id);
            _userRepository.Save();
            return Ok();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}