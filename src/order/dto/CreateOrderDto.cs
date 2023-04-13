using System.ComponentModel.DataAnnotations;
using FoodPool.user.entities;

namespace FoodPool.order.dto;

public class CreateOrderDto
{
    [Required] public int UserId { get; set; }
}