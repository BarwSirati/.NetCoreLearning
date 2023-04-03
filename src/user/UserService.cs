using System.Net;
using AutoMapper;
using FoodPool.data;
using FoodPool.user.dto;
using FoodPool.user.entities;
using FoodPool.user.interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodPool.user;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private readonly FoolpoolDbContext _context;

    public UserService(IMapper mapper, FoolpoolDbContext dbContext)
    {
        _mapper = mapper;
        _context = dbContext;
    }

    public async Task<List<GetUserDto>> GetAll()
    {
        List<GetUserDto> response;
        var query = await _context.User.ToListAsync();
        response = query.Select(c => _mapper.Map<GetUserDto>(c)).ToList();
        return response;
    }

    public async Task<GetUserDto> GetById(int id)
    {
        GetUserDto response;
        var query = await _context.User.FirstOrDefaultAsync(c => c.Id == id);
        response = _mapper.Map<GetUserDto>(query);
        return response;
    }

    public async Task<HttpStatusCode> Create(CreateUserDto createUserDto)
    {
        var user = _mapper.Map<UserEntity>(createUserDto);
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
        Console.WriteLine(user.Password);
        _context.User.Add(user);
        await _context.SaveChangesAsync();
        return HttpStatusCode.Created;
    }

    public async Task<GetUserDto> Update(UpdateUserDto updateUserDto, int id)
    {
        var user = await _context.User.FirstOrDefaultAsync(c => c.Id == id);
        if (user != null)
        {
            user.Name = updateUserDto.Name;
            user.Lastname = updateUserDto.Lastname;
            user.Password = BCrypt.Net.BCrypt.HashPassword(updateUserDto.Password);
            user.Tel = updateUserDto.Tel;
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }

        return _mapper.Map<GetUserDto>(user);
    }


    public async Task<HttpStatusCode> Delete(int id)
    {
        try
        {
            var user = await _context.User.FirstOrDefaultAsync(c => c.Id == id);
            if (user != null)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
            }
            else
            {
                return HttpStatusCode.NotFound;
            }

            return HttpStatusCode.OK;
        }
        catch (Exception exception)
        {
            return HttpStatusCode.BadRequest;
        }
    }
}