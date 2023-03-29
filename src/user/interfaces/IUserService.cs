using System.Net;
using FoodPool.user.dto;
using FoodPool.user.entities;

namespace FoodPool.user.interfaces;

public interface IUserService
{
    Task<List<GetUserDto>> GetAll();
    Task<GetUserDto> GetById(int id);
    Task<HttpStatusCode> Create(CreateUserDto createUserDto);
    
}