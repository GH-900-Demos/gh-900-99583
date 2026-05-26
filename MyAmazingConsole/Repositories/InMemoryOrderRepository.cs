using MyAmazingConsole.Models;

namespace MyAmazingConsole.Repositories;

/// <summary>
/// An in-memory implementation of <see cref="IOrderRepository"/> backed by a <see cref="Dictionary{TKey,TValue}"/>.
/// Suitable for testing and demo scenarios where persistence is not required.
/// </summary>
public class InMemoryOrderRepository : IOrderRepository
{
    private readonly Dictionary<Guid, Order> _store = new();

    /// <summary>
    /// Adds a new order to the in-memory store.
    /// </summary>
    /// <param name="order">The order to add.</param>
    /// <exception cref="InvalidOperationException">Thrown when an order with the same ID already exists.</exception>
    public void Add(Order order)
    {
        if (_store.ContainsKey(order.Id))
            throw new InvalidOperationException($"Order {order.Id} already exists.");
        _store[order.Id] = order;
    }

    /// <summary>
    /// Retrieves an order by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the order.</param>
    /// <returns>The matching <see cref="Order"/>, or <c>null</c> if not found.</returns>
    public Order? GetById(Guid id) =>
        _store.TryGetValue(id, out var order) ? order : null;

    /// <summary>
    /// Returns all orders currently held in the in-memory store.
    /// </summary>
    /// <returns>A read-only list of all <see cref="Order"/> instances.</returns>
    public IReadOnlyList<Order> GetAll() =>
        _store.Values.ToList().AsReadOnly();

    /// <summary>
    /// Returns all orders that match the specified status.
    /// </summary>
    /// <param name="status">The <see cref="OrderStatus"/> to filter by.</param>
    /// <returns>A read-only list of matching <see cref="Order"/> instances.</returns>
    public IReadOnlyList<Order> GetByStatus(OrderStatus status) =>
        _store.Values.Where(o => o.Status == status).ToList().AsReadOnly();

    /// <summary>
    /// Replaces the stored order with the provided updated instance.
    /// </summary>
    /// <param name="order">The order with updated data.</param>
    /// <exception cref="KeyNotFoundException">Thrown when no order with the given ID exists.</exception>
    public void Update(Order order)
    {
        if (!_store.ContainsKey(order.Id))
            throw new KeyNotFoundException($"Order {order.Id} not found.");
        _store[order.Id] = order;
    }

    /// <summary>
    /// Deletes the order with the specified identifier from the in-memory store.
    /// </summary>
    /// <param name="id">The unique identifier of the order to delete.</param>
    /// <exception cref="KeyNotFoundException">Thrown when no order with the given ID exists.</exception>
    public void Delete(Guid id)
    {
        if (!_store.Remove(id))
            throw new KeyNotFoundException($"Order {id} not found.");
    }
}
