
using SmartCart.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SmartCart.Api.Repositories
{
    public class ProductRepository
{
    private readonly List<Product> _products = new List<Product>
    {
        new Product { Id=1, Name="Laptop", Price=800, Stock=10 },
        new Product { Id=2, Name="Phone", Price=500, Stock=20 },
        new Product { Id=3, Name="Headphones", Price=100, Stock=50 },
    };

    public List<Product> GetAll() => _products;

    public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

    public void ReduceStock(int productId, int quantity)
    {
        var product = GetById(productId);
        if (product != null)
        {
            product.Stock -= quantity;
        }
    }
}
}
