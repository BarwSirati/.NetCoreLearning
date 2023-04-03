using FoodPool.user.dto;
using FoodPool.user.entities;

namespace FoodPool.user.interfaces;

public interface IUserRepository
{
    IEnumerable<UserEntity> GetAll();
    UserEntity GetById(int userId);
    void Insert(UserEntity userEntity);
    void Update(UpdateUserDto updateUserDto, int userId);
    void Delete(int userId);

    bool Exist(string username);
    void Save();
}