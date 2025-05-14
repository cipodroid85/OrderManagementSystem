using ProductService.Models;

namespace ProductService.Services;

public class ProductService : IProductService
{
    private readonly List<Product> _products = new();

    public IEnumerable<Product> GetAll() => _products;

    public Product? GetById(Guid id) =>
        _products.FirstOrDefault(p => p.Id == id);

    public void Add(Product product) => _products.Add(product);

    public void Update(Product updatedProduct)
    {
        var product = GetById(updatedProduct.Id);
        if (product is not null)
        {
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
        }
    }

    public void Delete(Guid id)
    {
        var product = GetById(id);
        if (product is not null)
            _products.Remove(product);
    }
}
