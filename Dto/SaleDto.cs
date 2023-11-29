namespace StoreManagerCs.Dto
{
    public class CreateSaleDto
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
    }

    public class ResponseSaleDto
    {
        public int SaleId { get; set; }
        public List<CreateSaleDto>? ItemsSold { get; set; }
    }
}