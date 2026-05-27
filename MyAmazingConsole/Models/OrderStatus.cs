namespace MyAmazingConsole.Models;

/// <summary>
/// Defines the lifecycle states an <see cref="Order"/> can be in.
/// </summary>
public enum OrderStatus
{
    /// <summary>The order has been created but not yet processed.</summary>
    Created,

    /// <summary>The order has been processed and fulfilled.</summary>
    Completed,

    /// <summary>The order has been dispatched and is on its way to the customer.</summary>
    Shipped,

    /// <summary>The order has been closed and is no longer active.</summary>
    Closed
}
