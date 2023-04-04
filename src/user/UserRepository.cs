using AutoMapper;
using FoodPool.data;
using FoodPool.user.dto;
using FoodPool.user.entities;
using FoodPool.user.interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodPool.user;

public class UserRepository : IUserRepository
{
    private readonly FoolpoolDbContext _context;

    public UserRepository(FoolpoolDbContext dbContext, IMapper mapper)
    {
        _context = dbContext;
    }

    public async Task<IEnumerable<UserEntity>> GetAll()
    {
        var users = await _context.User.ToListAsync();
        return users;
    }

    public async Task<UserEntity> GetById(int userId)
    {
        var user = await _context.User.FirstOrDefaultAsync(c => c.Id == userId)!;
        return user!;
    }

    public bool Exist(string username)
    {
        return _context.User.Any(u => u.Username == username);
    }

    public void Insert(UserEntity userEntity)
    {
        _context.User.AddAsync(userEntity);
    }

    public void Update(UpdateUserDto updateUserDto, int userId)
    {
        var user = GetById(userId);
        user.Result.Name = updateUserDto.Name;
        user.Result.Lastname = updateUserDto.Lastname;
        user.Result.Password = BCrypt.Net.BCrypt.HashPassword(updateUserDto.Password);
        user.Result.Tel = updateUserDto.Tel;
    }

    public void Delete(int userId)
    {
        var user = GetById(userId);
        _context.User.Remove(user.Result);
    }
    public bool ExistById(int userId)
    {
        return _context.User.Any(u => u.Id == userId);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}