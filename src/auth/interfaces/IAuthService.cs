using FluentResults;
using FoodPool.auth.dto;

namespace FoodPool.auth.interfaces;

public interface IAuthService
{
    Task<Result<JwtDto>> Login(AuthDto authDto);
}