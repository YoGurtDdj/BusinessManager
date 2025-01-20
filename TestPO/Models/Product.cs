namespace TestPO.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string BrandName { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Total { get; set; }
        public int Available { get; set; }
        public int Purchased { get; set; }
        public string Code { get; set; } = string.Empty;

        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
