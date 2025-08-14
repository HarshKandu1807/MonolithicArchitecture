namespace Domain.Entities;

public class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    // Domain invariants in ctor/factory
    public Product(string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required");
        if (price <= 0)
            throw new ArgumentException("Price must be > 0");

        Name = name.Trim();
        Price = price;
    }

    // Example domain behavior
    public void Rename(string newName)
    {
        if (string.IsNullOrWhiteSpace(newName))
            throw new ArgumentException("Name is required");
        Name = newName.Trim();
    }
}
