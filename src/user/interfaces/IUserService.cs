using System.Net;
using FoodPool.user.dto;

namespace FoodPool.user.interfaces;

public interface IUserService
{
    Task<List<GetUserDto>> GetAll();
    Task<GetUserDto> GetById(int id);
    Task<HttpStatusCode> Create(CreateUserDto createUserDto);

    Task<GetUserDto> Update(UpdateUserDto updateUserDto,int id);

    Task<HttpStatusCode> Delete(int id);

}