using System.ComponentModel.DataAnnotations;
using FoodPool.user.entities;

namespace FoodPool.order.entities;

public class OrderEntity
{
    [Key] public int Id { get; set; }
    public UserEntity User { get; set; }
}