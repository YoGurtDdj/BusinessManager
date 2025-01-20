namespace TestPO.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;

        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
