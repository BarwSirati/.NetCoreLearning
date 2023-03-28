using FoodPool.share.types;
using FoodPool.user.dto;
using FoodPool.user.entities;

namespace FoodPool.user.interfaces;

public interface IUserService
{
    Task<Response<List<GetUserDto>>> GetAll();
    Task<Response<GetUserDto>> GetById(int id);
    UserEntity Create(UserEntity userEntity);
}