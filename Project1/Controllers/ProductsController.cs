using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project1.Database;
using Project1.Entities;
using Project1.ProductService;

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Products>>> GetAllProducts()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProduct(int id)
        {
            var product = await _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Products>> AddProduct(Products product)
        {
             await _productService.AddProduct(product);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Products>>> UpdateProduct(int id, Products updateProduct)
        {
            updateProduct.Id = id; 
            var products = await _productService.UpdateProduct(updateProduct);
            if (products == null)
            {
                return NotFound("Product not found");
            }

            return Ok(products);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Products>>> DeleteProduct(int id)
        {
            var products = await _productService.DeleteProduct(id);
            if (products == null)
            {
                return NotFound("Product not found");
            }

            return Ok(products);

        }

    }
}
    
