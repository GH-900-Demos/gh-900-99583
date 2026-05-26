namespace MyAmazingConsole.Models;

public class OrderItem
{
    public string Code { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal UnitCost { get; set; }
    public decimal TotalCost => Quantity * UnitCost;

    public OrderItem(string code, string description, int quantity, decimal unitCost)
    {
        if (quantity <= 0)
            throw new ArgumentException("Quantity must be greater than zero.", nameof(quantity));
        if (unitCost < 0)
            throw new ArgumentException("Unit cost cannot be negative.", nameof(unitCost));

        Code = code;
        Description = description;
        Quantity = quantity;
        UnitCost = unitCost;
    }
}
