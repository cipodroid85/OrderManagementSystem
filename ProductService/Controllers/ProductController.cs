using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductService.Models;
using ProductService.Data;

namespace ProductService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductContext _context;

    public ProductController(ProductContext context)
    {
        _context = context;
    }

    // GET: api/Product
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAll()
    {
        var products = await _context.Products.ToListAsync();
        return Ok(products);
    }

    // GET: api/Product/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetById(Guid id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    // POST: api/Product
    [HttpPost]
    public async Task<ActionResult<Product>> Create(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    // PUT: api/Product/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Product updatedProduct)
    {
        if (id != updatedProduct.Id)
            return BadRequest("ID mismatch");

        var existing = await _context.Products.FindAsync(id);
        if (existing == null)
            return NotFound();

        existing.Name = updatedProduct.Name;
        existing.Price = updatedProduct.Price;

        await _context.SaveChangesAsync();
        return Ok(existing);
    }

    // DELETE: api/Product/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
            return NotFound();

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
