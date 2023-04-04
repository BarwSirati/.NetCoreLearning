using AutoMapper;
using FluentResults;
using FoodPool.user.dto;
using FoodPool.user.entities;
using FoodPool.user.interfaces;

namespace FoodPool.user;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<GetUserDto>> GetAll()
    {
        var users = await _userRepository.GetAll();
        return users.Select(c => _mapper.Map<GetUserDto>(c)).ToList();
    }

    public async Task<GetUserDto> GetById(int id)
    {
        var user = await _userRepository.GetById(id);
        return _mapper.Map<GetUserDto>(user);
    }

    public Result<GetUserDto> Create(CreateUserDto createUserDto)
    {
        try
        {
            var user = _mapper.Map<UserEntity>(createUserDto);
            if (_userRepository.Exist(createUserDto.Username!)) return Result.Fail(new Error("Conflict"));

            _userRepository.Insert(user);
            _userRepository.Save();
            return _mapper.Map<GetUserDto>(user);
        }
        catch (Exception)
        {
            return Result.Fail(new Error("Bad Request"));
        }
    }

    public async Task<Result<GetUserDto>> Update(UpdateUserDto updateUserDto, int id)
    {
        if (!_userRepository.ExistById(id)) return Result.Fail("Not Found");
        _userRepository.Update(updateUserDto, id);
        _userRepository.Save();
        return Result.Ok(await GetById(id));
    }

    public Result Delete(int id)
    {
        try
        {
            if (!_userRepository.ExistById(id)) return Result.Fail("Not Found");
            _userRepository.Delete(id);
            _userRepository.Save();
            return Result.Ok();
        }
        catch (Exception)
        {
            return Result.Fail("Bad Request");
        }
    }
}