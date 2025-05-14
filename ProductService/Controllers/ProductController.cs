using Microsoft.AspNetCore.Mvc;
using ProductService.Models;

namespace ProductService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private static readonly List<Product> _products = new();

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll() => Ok(_products);

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        _products.Add(product);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, Product updatedProduct)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product is null) return NotFound();

        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product is null) return NotFound();

        _products.Remove(product);
        return NoContent();
    }
}
