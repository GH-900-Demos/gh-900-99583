# MyAmazingApp

A simple .NET console application that demonstrates a basic order-management domain using an in-memory repository pattern.

## Goal

The project showcases how to model a small e-commerce domain in C# by combining:

- **Domain models** – `Customer`, `Order`, `OrderItem`, and the `OrderStatus` enum that together capture the lifecycle of a purchase.
- **Repository pattern** – the `IOrderRepository` interface and its `InMemoryOrderRepository` implementation provide a clean abstraction over data storage, making it straightforward to swap in a database-backed implementation later.
- **Console driver** – `Program.cs` exercises the full CRUD surface of the repository (add, update, query by status, look up by id, and delete).

## Class Diagram

```mermaid
classDiagram
    class Customer {
        +string FirstName
        +string LastName
        +string Address
        +Customer(firstName, lastName, address)
    }

    class Order {
        +Guid Id
        +Customer Customer
        +IReadOnlyList~OrderItem~ Items
        +decimal TotalCost
        +OrderStatus Status
        +DateTime CreatedAt
        +Order(customer)
        +AddItem(item)
        +RemoveItem(code)
        +UpdateStatus(status)
    }

    class OrderItem {
        +string Code
        +string Description
        +int Quantity
        +decimal UnitCost
        +decimal TotalCost
        +OrderItem(code, description, quantity, unitCost)
    }

    class OrderStatus {
        <<enumeration>>
        Created
        Completed
        Shipped
        Closed
    }

    class IOrderRepository {
        <<interface>>
        +Add(order)
        +GetById(id) Order
        +GetAll() IReadOnlyList~Order~
        +GetByStatus(status) IReadOnlyList~Order~
        +Update(order)
        +Delete(id)
    }

    class InMemoryOrderRepository {
        -Dictionary~Guid, Order~ _store
        +Add(order)
        +GetById(id) Order
        +GetAll() IReadOnlyList~Order~
        +GetByStatus(status) IReadOnlyList~Order~
        +Update(order)
        +Delete(id)
    }

    Order "1" --> "1" Customer : placed by
    Order "1" --> "0..*" OrderItem : contains
    Order --> OrderStatus : has status
    InMemoryOrderRepository ..|> IOrderRepository : implements
```
