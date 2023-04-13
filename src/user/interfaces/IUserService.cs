using FluentResults;
using FoodPool.user.dto;
using FoodPool.user.entities;

namespace FoodPool.user.interfaces;

public interface IUserService
{
    Task<List<GetUserDto>> GetAll();
    Task<GetUserDto> GetById(int id);

    Task<UserEntity?> GetByUsername(string username);
    Result<GetUserDto> Create(CreateUserDto createUserDto);

    Task<Result<GetUserDto>> Update(UpdateUserDto updateUserDto, int id);

    Result Delete(int id);
}