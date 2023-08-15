using Pustok.Database.Models;

namespace Pustok.Database.Repositories;

public class ProductRepository
{
    private static readonly List<Product> _products = new List<Product>();

    static ProductRepository()
    {
        _products.Add(new Product("Zogal", "this is desciada 4s", "black", "XS", 500));
        _products.Add(new Product("Alma", "this is desciadas", "red", "XS", 200));
        _products.Add(new Product("Heyva", "this is desciada2 s", "red", "XS", 400));
        _products.Add(new Product("Nar", "this is desciadas 3", "blue", "XS", 300));
    }

    public List<Product> GetAll()
    {
        return _products;
    }

    public void Insert(Product slideBanner)
    {
        _products.Add(slideBanner);
    }

    public Product GetById(int id)
    {
        return _products.FirstOrDefault(b => b.Id == id);
    }

    public void RemoveById(int id)
    {
        _products.RemoveAll(b => b.Id == id);
    }
}
