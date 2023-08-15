namespace Pustok.Database.Models;

public class Product
{
    private static int _idCounter = 1;

    public Product(string name, string decription, string color, string size, decimal price)
    {
        Id = _idCounter++;
        Name = name;
        Description = decription;
        Color = color;
        Size = size;
        Price = price;
    }

    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public string Size { get; set; }
    public decimal Price { get; set; }

}
