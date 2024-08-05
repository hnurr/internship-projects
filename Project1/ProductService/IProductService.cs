using Project1.Entities;

namespace Project1.ProductService
{
    public interface IProductService
    {
        Task<List<Products>> GetAllProducts();
        Task<Products> GetProduct(int id);
        Task  AddProduct(Products product);
        Task<List<Products>> UpdateProduct(Products updateProduct);
        Task<List<Products>> DeleteProduct(int id);
    }
}
