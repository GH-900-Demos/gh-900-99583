using MyAmazingConsole.Models;

namespace MyAmazingConsole.Repositories;

public class InMemoryOrderRepository : IOrderRepository
{
    private readonly Dictionary<Guid, Order> _store = new();

    public void Add(Order order)
    {
        if (_store.ContainsKey(order.Id))
            throw new InvalidOperationException($"Order {order.Id} already exists.");
        _store[order.Id] = order;
    }

    public Order? GetById(Guid id) =>
        _store.TryGetValue(id, out var order) ? order : null;

    public IReadOnlyList<Order> GetAll() =>
        _store.Values.ToList().AsReadOnly();

    public IReadOnlyList<Order> GetByStatus(OrderStatus status) =>
        _store.Values.Where(o => o.Status == status).ToList().AsReadOnly();

    public void Update(Order order)
    {
        if (!_store.ContainsKey(order.Id))
            throw new KeyNotFoundException($"Order {order.Id} not found.");
        _store[order.Id] = order;
    }

    public void Delete(Guid id)
    {
        if (!_store.Remove(id))
            throw new KeyNotFoundException($"Order {id} not found.");
    }
}
