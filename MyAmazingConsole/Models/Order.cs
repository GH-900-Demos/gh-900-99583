namespace MyAmazingConsole.Models;

/// <summary>
/// Represents a customer order containing one or more <see cref="OrderItem"/> entries.
/// </summary>
public class Order
{
    /// <summary>Gets the unique identifier for this order.</summary>
    public Guid Id { get; }

    /// <summary>Gets or sets the customer who placed this order.</summary>
    public Customer Customer { get; set; }

    /// <summary>Gets the read-only list of items included in this order.</summary>
    public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();

    /// <summary>Gets the total cost of all items in this order.</summary>
    public decimal TotalCost => _items.Sum(i => i.TotalCost);

    /// <summary>Gets the current status of this order.</summary>
    public OrderStatus Status { get; private set; }

    /// <summary>Gets the UTC date and time at which this order was created.</summary>
    public DateTime CreatedAt { get; }

    private readonly List<OrderItem> _items = new();

    /// <summary>
    /// Initializes a new instance of <see cref="Order"/> for the specified customer.
    /// The order is assigned a new unique identifier, set to <see cref="OrderStatus.Created"/>,
    /// and stamped with the current UTC time.
    /// </summary>
    /// <param name="customer">The customer placing the order.</param>
    public Order(Customer customer)
    {
        Id = Guid.NewGuid();
        Customer = customer;
        Status = OrderStatus.Created;
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>Adds an item to the order.</summary>
    /// <param name="item">The <see cref="OrderItem"/> to add.</param>
    public void AddItem(OrderItem item) => _items.Add(item);

    /// <summary>Removes all items with the specified product code from the order.</summary>
    /// <param name="code">The product code of the item(s) to remove.</param>
    public void RemoveItem(string code) =>
        _items.RemoveAll(i => i.Code == code);

    /// <summary>Updates the status of this order.</summary>
    /// <param name="status">The new <see cref="OrderStatus"/> value.</param>
    public void UpdateStatus(OrderStatus status) => Status = status;
}
