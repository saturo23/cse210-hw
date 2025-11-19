using System.Collections.Generic;

public class Order
{
    private List<Product> _products = new List<Product>();
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
    }

    public void AddProduct(Product p)
    {
        _products.Add(p);
    }

    public double GetTotalPrice()
    {
        double total = 0;

        foreach (Product p in _products)
        {
            total += p.GetTotalCost();
        }

        // Shipping cost
        if (_customer.LivesInUSA())
        {
            total += 5;
        }
        else
        {
            total += 35;
        }

        return total;
    }

    public string GetPackingLabel()
    {
        string result = "PACKING LABEL:\n";

        foreach (Product p in _products)
        {
            result += $"{p.GetName()} (ID: {p.GetID()})\n";
        }

        return result;
    }

    public string GetShippingLabel()
    {
        return $"SHIPPING LABEL:\n{_customer.GetName()}\n{_customer.GetAddress().GetFullAddress()}";
    }
}
