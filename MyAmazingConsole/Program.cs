using MyAmazingConsole.Models;
using MyAmazingConsole.Repositories;

// Create the in-memory repository through its interface
IOrderRepository orderRepository = new InMemoryOrderRepository();

// --- Example 1: create an order for a first customer ---
var alice = new Customer("Alice", "Smith", "123 Main St, Springfield");
var order1 = new Order(alice);
order1.AddItem(new OrderItem("BOOK-001", "C# in Depth", 2, 39.99m));
order1.AddItem(new OrderItem("PEN-042", "Blue ballpoint pen", 5, 1.20m));
orderRepository.Add(order1);

// --- Example 2: create another order and progress its status ---
var bob = new Customer("Bob", "Johnson", "456 Oak Ave, Metropolis");
var order2 = new Order(bob);
order2.AddItem(new OrderItem("LAPTOP-X1", "Developer laptop", 1, 1499.00m));
order2.AddItem(new OrderItem("MOUSE-7", "Wireless mouse", 1, 29.90m));
orderRepository.Add(order2);

order2.UpdateStatus(OrderStatus.Completed);
order2.UpdateStatus(OrderStatus.Shipped);
orderRepository.Update(order2);

// --- Example 3: remove an item from order1 ---
order1.RemoveItem("PEN-042");
orderRepository.Update(order1);

// --- Display all orders ---
Console.WriteLine("=== All orders ===");
foreach (var order in orderRepository.GetAll())
{
    PrintOrder(order);
}

// --- Query by status ---
Console.WriteLine("=== Shipped orders ===");
foreach (var order in orderRepository.GetByStatus(OrderStatus.Shipped))
{
    PrintOrder(order);
}

// --- Lookup by id ---
var fetched = orderRepository.GetById(order1.Id);
Console.WriteLine($"=== Fetched order {order1.Id} ===");
if (fetched is not null)
{
    PrintOrder(fetched);
}

// --- Delete an order ---
orderRepository.Delete(order2.Id);
Console.WriteLine($"Remaining orders after deleting Bob's order: {orderRepository.GetAll().Count}");

static void PrintOrder(Order order)
{
    Console.WriteLine($"Order {order.Id} [{order.Status}] - {order.Customer.FirstName} {order.Customer.LastName}");
    Console.WriteLine($"  Address: {order.Customer.Address}");
    foreach (var item in order.Items)
    {
        Console.WriteLine($"  - {item.Code} | {item.Description} | qty: {item.Quantity} x {item.UnitCost:C} = {item.TotalCost:C}");
    }
    Console.WriteLine($"  TOTAL: {order.TotalCost:C}");
    Console.WriteLine();
}
