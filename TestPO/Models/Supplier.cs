namespace TestPO.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
