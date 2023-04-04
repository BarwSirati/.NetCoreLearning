using FoodPool.order.dto;
using FoodPool.order.interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FoodPool.order;

[ApiController]
[Route("api/order")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<ActionResult<List<GetOrderDto>>> GetAll()
    {
        var orders = await _orderService.GetAll();
        return orders;
    }

    [HttpPost]
    public async Task<ActionResult<GetOrderDto>> Create(CreateOrderDto createOrderDto)
    {
        var order = await _orderService.Create(createOrderDto);
        if (order.IsFailed) return BadRequest();
        return order.Value;
    }
}