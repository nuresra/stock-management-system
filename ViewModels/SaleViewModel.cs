using System.Collections.Generic;
using StockManagementSystem.Models;

namespace StockManagementSystem.ViewModels
{
    public class SaleViewModel
    {
        public List<Product> Products { get; set; }
        public int ProductId { get; set; } // Ürün ID'si
        public int Quantity { get; set; } // Miktar
        public decimal TotalPrice { get; set; } // Toplam Fiyat
        public List<SaleItem> SaleItems { get; set; } = new List<SaleItem>();
    }
}
