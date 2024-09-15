using StockManagementSystem.Models;

namespace StockManagementSystem.ViewModels
{
    public class SaleViewModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime SaleDate { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }

}
