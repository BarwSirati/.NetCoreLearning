using FoodPool.data;
using FoodPool.order.entities;
using FoodPool.order.interfaces;
using Microsoft.EntityFrameworkCore;

namespace FoodPool.order;

public class OrderRepository : IOrderRepository
{
    private readonly FoolpoolDbContext _context;

    public OrderRepository(FoolpoolDbContext foolpoolDbContext)
    {
        _context = foolpoolDbContext;
    }

    public async Task<List<OrderEntity>> GetAll()
    {
        var orders = await _context.Order.Include(o => o.User).ToListAsync();
        return orders;
    }

    public void Insert(OrderEntity orderEntity)
    {
        _context.Order.AddAsync(orderEntity);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}