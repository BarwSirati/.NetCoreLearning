using AutoMapper;
using FoodPool.data;
using FoodPool.share.types;
using FoodPool.user.dto;
using FoodPool.user.entities;
using FoodPool.user.interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodPool.user;

public class UserService : IUserService
{
    private readonly List<UserEntity?> _userEntity = new List<UserEntity?>
    {
        new UserEntity { Id = 1, Name = "bxdman" },
        new UserEntity { Id = 2, Name = "bxdman" }
    };


    private readonly IMapper _mapper;
    private readonly FoolpoolDbContext _context;

    public UserService(IMapper mapper, FoolpoolDbContext dbContext)
    {
        _mapper = mapper;
        _context = dbContext;
    }

    public async Task<Response<List<GetUserDto>>> GetAll()
    {
        var response = new Response<List<GetUserDto>>();
        var query = await _context.User.ToListAsync();
        response.Data = query.Select(c => _mapper.Map<GetUserDto>(c)).ToList();
        return response;
    }

    public async Task<Response<GetUserDto>> GetById(int id)
    {
        var response = new Response<GetUserDto>();
        var query = await _context.User.FirstOrDefaultAsync(c => c.Id == id);
        response.Data = _mapper.Map<GetUserDto>(query);
        return response;
    }

    public async Task<Response<GetUserDto>> Create(CreateUserDto createUserDto)
    {
        var response = new Response<GetUserDto>();
        var user = _mapper.Map<UserEntity>(createUserDto);
    
        _context.User.Add(user);
        await _context.SaveChangesAsync();
        return response;
    }
}