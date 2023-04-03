using AutoMapper;
using FoodPool.data;
using FoodPool.user.dto;
using FoodPool.user.entities;
using FoodPool.user.interfaces;

namespace FoodPool.user;

public class UserRepository : IUserRepository
{
    private readonly FoolpoolDbContext _context;

    public UserRepository(FoolpoolDbContext dbContext, IMapper mapper)
    {
        _context = dbContext;
    }

    public IEnumerable<UserEntity> GetAll()
    {
        var users = _context.User;
        return users;
    }

    public UserEntity GetById(int userId)
    {
        var user = _context.User.FirstOrDefault(c => c.Id == userId)!;
        return user;
    }

    public bool Exist(string username)
    {
        return _context.User.Any(u => u.Username == username);
    }

    public void Insert(UserEntity userEntity)
    {
        var user = _context.User.FirstOrDefault(c => c.Username == userEntity.Username);
        if (user == null)
        {
            userEntity.Password = BCrypt.Net.BCrypt.HashPassword(userEntity.Password);
            _context.User.Add(userEntity);
        }
    }

    public void Update(UpdateUserDto updateUserDto, int userId)
    {
        var user = GetById(userId);
        if (user != null!)
        {
            user.Name = updateUserDto.Name;
            user.Lastname = updateUserDto.Lastname;
            user.Password = BCrypt.Net.BCrypt.HashPassword(updateUserDto.Password);
            user.Tel = updateUserDto.Tel;
        }
    }

    public void Delete(int userId)
    {
        var user = GetById(userId);
        if (user != null!)
        {
            _context.User.Remove(user);
        }
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}