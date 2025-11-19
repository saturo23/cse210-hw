using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the OnlineOrdering Project.");
        // Create addresses
        Address a1 = new Address("123 Main St", "Phoenix", "AZ", "USA");
        Address a2 = new Address("12 Kings Road", "London", "LDN", "UK");

        // Create customers
        Customer c1 = new Customer("John Smith", a1);
        Customer c2 = new Customer("Sarah Brown", a2);

        // Create orders
        Order order1 = new Order(c1);
        order1.AddProduct(new Product("Laptop", "P001", 850, 1));
        order1.AddProduct(new Product("USB Cable", "P002", 5, 3));

        Order order2 = new Order(c2);
        order2.AddProduct(new Product("Desk Lamp", "P010", 30, 2));
        order2.AddProduct(new Product("Notebook", "P011", 3, 5));

        // Display order 1
        Console.WriteLine("--------------------------------------");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalPrice()}\n");

        // Display order 2
        Console.WriteLine("--------------------------------------");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.GetTotalPrice()}\n");
    }
}