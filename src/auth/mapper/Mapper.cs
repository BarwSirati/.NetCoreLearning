using AutoMapper;
using FoodPool.auth.dto;
using FoodPool.auth.entities;

namespace FoodPool.auth.mapper;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<AuthDto, AuthEntity>();
        CreateMap<JwtEntity, JwtDto>();
    }
}