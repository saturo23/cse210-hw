public class Product
{
    private string _name;
    private string _id;
    private double _pricePerUnit;
    private int _quantity;

    public Product(string name, string id, double price, int quantity)
    {
        _name = name;
        _id = id;
        _pricePerUnit = price;
        _quantity = quantity;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetID()
    {
        return _id;
    }

    public double GetTotalCost()
    {
        return _pricePerUnit * _quantity;
    }
}
