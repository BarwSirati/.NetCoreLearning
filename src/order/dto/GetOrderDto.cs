using FoodPool.user.entities;

namespace FoodPool.order.dto;

public class GetOrderDto
{
    public int Id { get; set; }
    public UserEntity User { get; set; }
}