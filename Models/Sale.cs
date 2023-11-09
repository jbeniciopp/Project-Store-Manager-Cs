namespace StoreManagerCs.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Sale {
    [Key]
    public int SaleId { get; set; }
    public DateTime Date { get; set; }
    public List<SaleProduct>? SaleProducts {get; set;}
}