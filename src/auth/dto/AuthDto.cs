using System.ComponentModel.DataAnnotations;

namespace FoodPool.auth.dto;

public class AuthDto
{
    [Required]
    public string? Username { get; set; }
    
    [Required]
    public string? Password { get; set; }
}