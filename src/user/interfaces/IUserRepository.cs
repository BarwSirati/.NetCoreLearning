using FoodPool.user.dto;
using FoodPool.user.entities;

namespace FoodPool.user.interfaces;

public interface IUserRepository
{
    Task<List<UserEntity>> GetAll();
    Task<UserEntity?> GetById(int userId);

    Task<UserEntity?> GetByUsername(string username);
    void Insert(UserEntity userEntity);
    void Update(UpdateUserDto updateUserDto, int userId);
    void Delete(int userId);

    bool Exist(string username);

    bool ExistById(int userId);
    void Save();
}