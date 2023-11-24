using StoreManagerCs.Models;
using StoreManagerCs.Dto;

namespace StoreManagerCs.Repository
{
    public class SaleProductsRepository : ISaleProductsRepository
    {
        protected readonly IStoreManagerCsContext _context;
        public SaleProductsRepository(StoreManagerCsContext context)
        {
            _context = context;
        }

        public SaleProduct AddSaleProducts(Sale sale, Product product, int quantity)
        {
            var salesProducts = _context.SaleProducts;

            SaleProduct newSaleProduct = new()
            {
                Sale = sale,
                Product = product,
                Quantity = quantity
            };

            salesProducts.Add(newSaleProduct);
            _context.SaveChanges();

            return newSaleProduct;
        }
    }
}