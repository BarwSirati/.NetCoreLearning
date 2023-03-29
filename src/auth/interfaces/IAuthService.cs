using FluentResults;
using FoodPool.auth.dto;
using Microsoft.AspNetCore.Mvc;

namespace FoodPool.auth.interfaces;

public interface IAuthService
{
    Task<Result<JwtDto>> Login(AuthDto authDto);
}