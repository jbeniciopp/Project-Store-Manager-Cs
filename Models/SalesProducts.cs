namespace StoreManagerCs.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SaleProduct {
    [Key]
    public int SaleProductId { get; set; }
    [ForeignKey("SaleId")]
    public Sale? Sale { get; set; }
    [ForeignKey("ProductId")]
    public Product? Product { get; set; }
    public int Quantity { get; set; }
}