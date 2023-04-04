using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FoodPool.user.entities;

[Index(nameof(Username), IsUnique = true)]
public class UserEntity
{
    [Key] public int Id { get; set; }

    [StringLength(50)] public string? Name { get; set; }

    [StringLength(50)] public string? Lastname { get; set; }

    [StringLength(50)] public string? Username { get; set; }
    public string? Password { get; set; }

    [StringLength(10)]
    [MaxLength(10)]
    public string? Tel { get; set; }
}