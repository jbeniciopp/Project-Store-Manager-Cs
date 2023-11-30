using StoreManagerCs.Models;
using StoreManagerCs.Dto;
using Microsoft.EntityFrameworkCore;

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

        public void DeleteSales(int SaleId)
        {
            var sales = _context.SaleProducts;

            var sale = sales
                .Include(sp => sp.Sale)
                .Include(sp => sp.Product)
                .Where(s => s.Sale.SaleId == SaleId).ToList();

            if (sale.Count == 0)
            {
                throw new System.Exception();
            }

            for (int i = 0; i < sale.Count(); i++)
            {
                sales.Remove(sale[i]);
            }

            _context.SaveChanges();
        }

        public List<SaleProduct> GetSaleProductsBySaleId(int saleId)
        {
            var salesProducts = _context.SaleProducts
                .Include(sp => sp.Sale)
                .Include(sp => sp.Product)
                .Where(sp => sp.Sale != null && sp.Sale.SaleId == saleId)
                .ToList();

            return salesProducts;
        }
    }
}