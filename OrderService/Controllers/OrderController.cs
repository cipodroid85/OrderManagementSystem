using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using OrderService.Services;

namespace OrderService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _service;

    public OrderController(IOrderService service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        var order = _service.GetById(id);
        return order is null ? NotFound() : Ok(order);
    }

    [HttpPost]
    public IActionResult Create(Order order)
    {
        _service.Add(order);
        return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, Order updatedOrder)
    {
        updatedOrder.Id = id;
        _service.Update(updatedOrder);
        return Ok(updatedOrder);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        _service.Delete(id);
        return NoContent();
    }
}
