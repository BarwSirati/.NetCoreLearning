using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPool.user.entities;

public class UserEntity
{
    [Key]
    public int Id { get; set; }
    
    [StringLength(50)]
    public string? Name { get; set; }
    
    [StringLength(50)]
    public string? Lastname { get; set; }
}