using StoreManagerCs.Models;
using StoreManagerCs.Dto;

namespace StoreManagerCs.Repository
{
    public class ProductRepository : IProductRepository
    {
        protected readonly IStoreManagerCsContext _context;
        public ProductRepository(StoreManagerCsContext context)
        {
            _context = context;
        }

        public List<ProductDto> GetProducts()
        {
            var products = _context.Products;
            
            var allProducts = (from product in products
                                select new ProductDto
                                {
                                    ProductId = product.ProductId,
                                    Name = product.Name
                                }).ToList();

            return allProducts;
        }

        public Product GetProductById(int ProductId)
        {
            var products = _context.Products;
            
            var response = (from product in products
                            where product.ProductId == ProductId
                            select product).ToList();

            return response.FirstOrDefault();
        }

        public ProductDto AddProduct(Product product)
        {
            var products = _context.Products;

            products.Add(product);
            _context.SaveChanges();

            var productDto = new ProductDto {
                ProductId = product.ProductId,
                Name = product.Name
            };

            return productDto;
        }

        public ProductDto UpdateProduct(Product product)
        {
            var products = _context.Products;

            products.Update(product);
            _context.SaveChanges();

            var productDto = new ProductDto {
                ProductId = product.ProductId,
                Name = product.Name
            };

            return productDto;
        }

        public void DeleteProduct(int ProductId)
        {
            var products = _context.Products;

            var product = products.Find(ProductId) ?? throw new System.Exception();

            products.Remove(product);
            _context.SaveChanges();
        }
    }
}