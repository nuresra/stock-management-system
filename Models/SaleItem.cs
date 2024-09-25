using System.ComponentModel.DataAnnotations;

namespace StockManagementSystem.Models
{
    public class SaleItem
    {
        public int Id { get; set; }

        [Required]
        public int SaleId { get; set; }
        public Sale Sale { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return Product.Price * Quantity;
            }
        }
    }
}
