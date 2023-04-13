using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using FluentResults;
using FoodPool.auth.dto;
using FoodPool.auth.interfaces;
using FoodPool.data;
using FoodPool.user.entities;
using FoodPool.user.interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FoodPool.auth;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public AuthService(IUserService userService, IMapper mapper, IConfiguration configuration)
    {
        _mapper = mapper;
        _userService = userService;
        _configuration = configuration;
    }

    public async Task<Result<JwtDto>> Login(AuthDto authDto)
    {
        var user = await _userService.GetByUsername(authDto.Username!);
        if (user is null) return Result.Fail("Bad Request");

        if (!BCrypt.Net.BCrypt.Verify(authDto.Password, user.Password)) return Result.Fail("Bad Request");

        var jwtDto = new JwtDto
        {
            Token = CreateToken(user)
        };
        return jwtDto;
    }

    private string CreateToken(UserEntity userEntity)
    {
        var claim = new List<Claim>
        {
            new Claim("userId", userEntity.Id.ToString())
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["secretKey"]!));
        var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        if (credential == null) throw new ArgumentNullException(nameof(credential));
        var token = new JwtSecurityToken(claims: claim, expires: DateTime.UtcNow.AddDays(7),
            signingCredentials: credential);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}