using Microsoft.EntityFrameworkCore;
using StoreManagerCs.Models;

namespace StoreManagerCs.Repository;
public class StoreManagerCsContext : DbContext, IStoreManagerCsContext
{
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Sale> Sales { get; set; } = null!;
    public DbSet<SaleProduct> SaleProducts { get; set; } = null!;
    public StoreManagerCsContext() { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=StoreManager;User=SA;Password=StoreManager2!;TrustServerCertificate=True";
        optionsBuilder.UseSqlServer(connectionString);

        // Para realizar o deploy deverá comentar o código acima e decomentar o código abaixo.

        // var connectionString = "Server=localhost;User Id=root;Password=123456;Port=3308;Database=ContactDB;";
        // optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), null);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {}

}