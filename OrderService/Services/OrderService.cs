using OrderService.Models;

namespace OrderService.Services;

public class OrderService : IOrderService
{
    private readonly List<Order> _orders = new();

    public IEnumerable<Order> GetAll() => _orders;

    public Order? GetById(Guid id) =>
        _orders.FirstOrDefault(o => o.Id == id);

    public void Add(Order order) => _orders.Add(order);

    public void Update(Order updatedOrder)
    {
        var order = GetById(updatedOrder.Id);
        if (order != null)
        {
            order.ProductId = updatedOrder.ProductId;
            order.Quantity = updatedOrder.Quantity;
        }
    }

    public void Delete(Guid id)
    {
        var order = GetById(id);
        if (order != null)
            _orders.Remove(order);
    }
}
