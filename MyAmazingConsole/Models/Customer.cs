namespace MyAmazingConsole.Models;

/// <summary>
/// Represents a customer who can place orders.
/// </summary>
public class Customer
{
    /// <summary>Gets or sets the customer's first name.</summary>
    public string FirstName { get; set; }

    /// <summary>Gets or sets the customer's last name.</summary>
    public string LastName { get; set; }

    /// <summary>Gets or sets the customer's shipping address.</summary>
    public string Address { get; set; }

    /// <summary>
    /// Initializes a new instance of <see cref="Customer"/> with the specified details.
    /// </summary>
    /// <param name="firstName">The customer's first name.</param>
    /// <param name="lastName">The customer's last name.</param>
    /// <param name="address">The customer's shipping address.</param>
    public Customer(string firstName, string lastName, string address)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
    }
}
