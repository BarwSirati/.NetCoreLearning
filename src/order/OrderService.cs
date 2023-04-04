using AutoMapper;
using FluentResults;
using FoodPool.order.dto;
using FoodPool.order.entities;
using FoodPool.order.interfaces;
using FoodPool.user.entities;
using FoodPool.user.interfaces;

namespace FoodPool.order;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public OrderService(IUserRepository userRepository, IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<List<GetOrderDto>> GetAll()
    {
        var orders = await _orderRepository.GetAll();
        return orders.Select(o => _mapper.Map<GetOrderDto>(o)).ToList();
    }

    public async Task<Result<GetOrderDto>> Create(CreateOrderDto createOrderDto)
    {
        var user = await _userRepository.GetById(createOrderDto.userId);
        if (user is null) return Result.Fail("Not Found");

        var order = new OrderEntity();
        order.User = user;
        _orderRepository.Insert(order);
        _orderRepository.Save();
        return _mapper.Map<GetOrderDto>(order);
    }
}