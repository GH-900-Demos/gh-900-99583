using MyAmazingConsole.Models;

namespace MyAmazingConsole.Repositories;

/// <summary>
/// Defines the contract for a repository that manages <see cref="Order"/> persistence.
/// </summary>
public interface IOrderRepository
{
    /// <summary>Adds a new order to the repository.</summary>
    /// <param name="order">The order to add.</param>
    void Add(Order order);

    /// <summary>Retrieves an order by its unique identifier.</summary>
    /// <param name="id">The unique identifier of the order.</param>
    /// <returns>The matching <see cref="Order"/>, or <c>null</c> if not found.</returns>
    Order? GetById(Guid id);

    /// <summary>Returns all orders currently held in the repository.</summary>
    /// <returns>A read-only list of all <see cref="Order"/> instances.</returns>
    IReadOnlyList<Order> GetAll();

    /// <summary>Returns all orders that match the specified status.</summary>
    /// <param name="status">The <see cref="OrderStatus"/> to filter by.</param>
    /// <returns>A read-only list of matching <see cref="Order"/> instances.</returns>
    IReadOnlyList<Order> GetByStatus(OrderStatus status);

    /// <summary>Updates an existing order in the repository.</summary>
    /// <param name="order">The order with updated data.</param>
    void Update(Order order);

    /// <summary>Deletes the order with the specified identifier from the repository.</summary>
    /// <param name="id">The unique identifier of the order to delete.</param>
    void Delete(Guid id);
}
