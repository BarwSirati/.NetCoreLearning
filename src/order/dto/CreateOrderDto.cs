using System.ComponentModel.DataAnnotations;
using FoodPool.user.entities;

namespace FoodPool.order.dto;

public class CreateOrderDto
{
    [Required] public int userId { get; set; }
}