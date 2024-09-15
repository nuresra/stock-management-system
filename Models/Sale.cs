using System.ComponentModel.DataAnnotations;

namespace StockManagementSystem.Models
{
    public class Sale
    {
        public int Id { get; set; }

        [Required] // Satışta ürünün olması zorunlu
        public int ProductId { get; set; }

        [Required] // Her satış bir ürüne ait olmalı
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime SaleDate { get; set; }
    }

}
