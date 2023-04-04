using FluentResults;
using FoodPool.order.dto;

namespace FoodPool.order.interfaces;

public interface IOrderService
{
    Task<List<GetOrderDto>> GetAll();
    Task<Result<GetOrderDto>> Create(CreateOrderDto createOrderDto);
}