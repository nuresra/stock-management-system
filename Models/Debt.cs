namespace StockManagementSystem.Models
{
    public class Debt
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal DebtAmount { get; set; }
        public DateTime DebtDate { get; set; }
    }

}
