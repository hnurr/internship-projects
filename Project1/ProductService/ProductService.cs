using Microsoft.EntityFrameworkCore;
using Project1.Database;
using Project1.Entities;

namespace Project1.ProductService 
{
  public class ProductService : IProductService { 

    private readonly DataContext _context;

    public ProductService(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Products>> GetAllProducts()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Products> GetProduct(int id)
    {

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return null;
            }
            return product;
        }

    public async Task AddProduct(Products product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        
             
    }

    public async Task<List<Products>> UpdateProduct(Products updateProduct)
    {
        var dbProduct = await _context.Products.FindAsync(updateProduct.Id);
        if (dbProduct == null) return null;

        dbProduct.Name = updateProduct.Name;
        dbProduct.Price = updateProduct.Price;

        await _context.SaveChangesAsync();

            return await _context.Products.ToListAsync();
    }

    public async Task<List<Products>> DeleteProduct(int id)
    {
        var dbProduct = await _context.Products.FindAsync(id);
        if (dbProduct == null) return null;

        _context.Products.Remove(dbProduct);
        await _context.SaveChangesAsync();

        return await _context.Products.ToListAsync();
    }
}
}

