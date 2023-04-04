using FluentResults;
using FoodPool.user.dto;

namespace FoodPool.user.interfaces;

public interface IUserService
{
    Task<List<GetUserDto>> GetAll();
    Task<GetUserDto> GetById(int id);
    Result<GetUserDto> Create(CreateUserDto createUserDto);

    Task<Result<GetUserDto>> Update(UpdateUserDto updateUserDto, int id);

    Result Delete(int id);
}