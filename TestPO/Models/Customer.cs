namespace TestPO.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string PersonType { get; set; } = "None";
        public int Total { get; set; }
        public int ToPay { get; set; }
        public int Rest { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
