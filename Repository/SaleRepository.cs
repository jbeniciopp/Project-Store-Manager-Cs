using StoreManagerCs.Models;
using StoreManagerCs.Dto;

namespace StoreManagerCs.Repository
{
    public class SaleRepository : ISaleRepository
    {
        protected readonly IStoreManagerCsContext _context;
        public SaleRepository(StoreManagerCsContext context)
        {
            _context = context;
        }

        public Sale AddSale()
        {
            var sales = _context.Sales;

            Sale newSale = new()
            {
                Date = DateTime.Now
            };

            sales.Add(newSale);
            _context.SaveChanges();

            return newSale;
        }

        public List<Sale> GetSales()
        {
            var sales = _context.Sales.ToList();

            return sales;
        }
    }
}