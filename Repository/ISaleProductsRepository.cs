using StoreManagerCs.Models;
using StoreManagerCs.Dto;

namespace StoreManagerCs.Repository
{
    public interface ISaleProductsRepository
    {
        SaleProduct AddSaleProducts(Sale sale, Product product, int quantity);
        List<SaleProduct> GetSaleProductsBySaleId(int saleId);
        void DeleteSales(int saleId);
    }
}