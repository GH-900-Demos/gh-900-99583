namespace MyAmazingConsole.Models;

public class Customer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }

    public Customer(string firstName, string lastName, string address)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
    }
}
