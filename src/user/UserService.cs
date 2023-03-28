using AutoMapper;
using FoodPool.share.types;
using FoodPool.user.dto;
using FoodPool.user.entities;
using FoodPool.user.interfaces;

namespace FoodPool.user;

public class UserService : IUserService
{
    private readonly List<UserEntity?> _userEntity = new List<UserEntity?>
    {
        new UserEntity { Id = 1, Name = "bxdman" },
        new UserEntity { Id = 2, Name = "bxdman" }
    };

    private readonly IMapper _mapper;
    
    public UserService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<Response<List<GetUserDto>>> GetAll()
    {
        var query = new Response<List<GetUserDto>>();
        query.Data = _userEntity.Select(c => _mapper.Map<GetUserDto>(c)).ToList();
        return query;
    }

    public async Task<Response<GetUserDto>> GetById(int id)
    {
        var query = new Response<GetUserDto>();
        var user = this._userEntity.FirstOrDefault((c) => c?.Id == id);
        query.Data = _mapper.Map<GetUserDto>(user);
        return query;
    }

    public UserEntity Create(UserEntity userEntity)
    {
        this._userEntity.Add(userEntity);
        return userEntity;
    }
}