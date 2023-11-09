using Microsoft.EntityFrameworkCore;
using StoreManagerCs.Models;

namespace StoreManagerCs.Repository
{
    public interface IStoreManagerCsContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleProduct> SaleProducts { get; set; }
        public int SaveChanges();
    }
}