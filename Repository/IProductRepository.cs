using StoreManagerCs.Models;
using StoreManagerCs.Dto;

namespace StoreManagerCs.Repository
{
    public interface IProductRepository
    {
        List<ProductDto> GetProducts();
        Product GetProductById(int ProductId);
        ProductDto AddProduct(Product product);
        ProductDto UpdateProduct(Product product);
        void DeleteProduct(int ProductId);
    }
}