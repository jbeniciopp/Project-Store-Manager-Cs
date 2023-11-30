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

        public void DeleteSale(int SaleId)
        {
            var sales = _context.Sales;

            var sale = sales.Where(s => s.SaleId == SaleId).ToList();
            
            if (sale.Count == 0)
            {
                throw new System.Exception();
            }

            sales.Remove(sale.First());
            _context.SaveChanges();
        }

        public List<Sale> GetSales()
        {
            var sales = _context.Sales.ToList();

            return sales;
        }
    }
}