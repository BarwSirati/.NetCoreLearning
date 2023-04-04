using AutoMapper;
using FoodPool.auth.dto;
using FoodPool.auth.entities;
using FoodPool.order.dto;
using FoodPool.order.entities;
using FoodPool.user.dto;
using FoodPool.user.entities;

namespace FoodPool;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<UserEntity, GetUserDto>();
        CreateMap<OrderEntity, GetOrderDto>();

        CreateMap<CreateUserDto, UserEntity>();
        CreateMap<CreateOrderDto, OrderEntity>();

        CreateMap<UpdateUserDto, UserEntity>();
        
        CreateMap<AuthDto, AuthEntity>();
        CreateMap<JwtEntity, JwtDto>();
    }
}