namespace MyAmazingConsole.Models;

public class Order
{
    public Guid Id { get; }
    public Customer Customer { get; set; }
    public IReadOnlyList<OrderItem> Items => _items.AsReadOnly();
    public decimal TotalCost => _items.Sum(i => i.TotalCost);
    public OrderStatus Status { get; private set; }
    public DateTime CreatedAt { get; }

    private readonly List<OrderItem> _items = new();

    public Order(Customer customer)
    {
        Id = Guid.NewGuid();
        Customer = customer;
        Status = OrderStatus.Created;
        CreatedAt = DateTime.UtcNow;
    }

    public void AddItem(OrderItem item) => _items.Add(item);

    public void RemoveItem(string code) =>
        _items.RemoveAll(i => i.Code == code);

    public void UpdateStatus(OrderStatus status) => Status = status;
}
