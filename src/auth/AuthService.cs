using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using FluentResults;
using FoodPool.auth.dto;
using FoodPool.auth.interfaces;
using FoodPool.data;
using FoodPool.user.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FoodPool.auth;

public class AuthService : IAuthService
{
    private readonly FoolpoolDbContext _context;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public AuthService(FoolpoolDbContext dbContext, IMapper mapper, IConfiguration configuration)
    {
        _mapper = mapper;
        _context = dbContext;
        _configuration = configuration;
    }

    public async Task<Result<JwtDto>> Login(AuthDto authDto)
    {
        // Console.WriteLine(_configuration["secretKey"]);
        var user = await _context.User.FirstOrDefaultAsync(c => c.Username == authDto.Username);
        if (user == null)
            return Result.Fail("Bad Request");

        if (!BCrypt.Net.BCrypt.Verify(authDto.Password, user.Password))
            return Result.Fail("Bad Request");

        JwtDto jwtDto = new JwtDto();
        jwtDto.Token = CreateToken(user);
        return jwtDto;
    }

    private string CreateToken(UserEntity userEntity)
    {
        var claim = new List<Claim>
        {
            new Claim("userId", userEntity.Id.ToString())
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["secretKey"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(claims: claim, expires: DateTime.UtcNow.AddDays(7), signingCredentials: creds);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}