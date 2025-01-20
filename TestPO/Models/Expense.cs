namespace TestPO.Models
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public int ExpenseCost { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;

        public int? UserId { get; set; }
        public User? User { get; set; }
    }
}
