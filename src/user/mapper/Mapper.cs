using AutoMapper;
using FoodPool.user.dto;
using FoodPool.user.entities;

namespace FoodPool.user.mapper;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<UserEntity, GetUserDto>();
    }
}