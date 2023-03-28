using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPool.user.entities;

public class UserEntity
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
}