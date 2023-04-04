using FoodPool.order.entities;

namespace FoodPool.order.interfaces;

public interface IOrderRepository
{
    Task<List<OrderEntity>> GetAll();
    void Insert(OrderEntity orderEntity);

    void Save();
}