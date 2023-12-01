using StoreManagerCs.Models;
using StoreManagerCs.Dto;

namespace StoreManagerCs.Repository
{
    public interface ISaleRepository
    {
        Sale AddSale();
        List<Sale> GetSales();
        Sale GetSaleById(int SaleId);
        void DeleteSale(int saleId);
    }
}