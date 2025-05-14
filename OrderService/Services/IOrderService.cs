using OrderService.Models;

namespace OrderService.Services;

public interface IOrderService
{
	IEnumerable<Order> GetAll();
	Order? GetById(Guid id);
	void Add(Order order);
	void Update(Order order);
	void Delete(Guid id);
}
