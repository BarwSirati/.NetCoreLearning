using AutoMapper;
using FoodPool.auth.dto;
using FoodPool.auth.entities;
using FoodPool.user.dto;
using FoodPool.user.entities;

namespace FoodPool.user.mapper;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<UserEntity, GetUserDto>();
        CreateMap<CreateUserDto,UserEntity>();
        CreateMap<UpdateUserDto, UserEntity>();
    }
}