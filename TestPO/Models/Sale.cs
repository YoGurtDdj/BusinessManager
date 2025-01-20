namespace TestPO.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public int ReceiptNumber { get; set; }
        public int CustomerId { get; set; }
        public Customer? Client { get; set;}
        public int Quantity { get; set; }
        public int TotalSum { get; set; }
        public string Date { get; set; } = string.Empty;


        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
