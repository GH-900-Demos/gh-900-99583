namespace MyAmazingConsole.Models;

/// <summary>
/// Represents a single line item within an <see cref="Order"/>.
/// </summary>
public class OrderItem
{
    /// <summary>Gets or sets the unique product code for this item.</summary>
    public string Code { get; set; }

    /// <summary>Gets or sets the human-readable description of this item.</summary>
    public string Description { get; set; }

    /// <summary>Gets or sets the number of units ordered.</summary>
    public int Quantity { get; set; }

    /// <summary>Gets or sets the cost per unit.</summary>
    public decimal UnitCost { get; set; }

    /// <summary>Gets the total cost for this line item (<see cref="Quantity"/> × <see cref="UnitCost"/>).</summary>
    public decimal TotalCost => Quantity * UnitCost;

    /// <summary>
    /// Initializes a new instance of <see cref="OrderItem"/> with the specified details.
    /// </summary>
    /// <param name="code">The unique product code.</param>
    /// <param name="description">A description of the product.</param>
    /// <param name="quantity">The number of units ordered. Must be greater than zero.</param>
    /// <param name="unitCost">The cost per unit. Must not be negative.</param>
    /// <exception cref="ArgumentException">
    /// Thrown when <paramref name="quantity"/> is less than or equal to zero,
    /// or when <paramref name="unitCost"/> is negative.
    /// </exception>
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
