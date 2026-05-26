using MyAmazingConsole.Models;

namespace MyAmazingConsole.Repositories;

public interface IOrderRepository
{
    void Add(Order order);
    Order? GetById(Guid id);
    IReadOnlyList<Order> GetAll();
    IReadOnlyList<Order> GetByStatus(OrderStatus status);
    void Update(Order order);
    void Delete(Guid id);
}
