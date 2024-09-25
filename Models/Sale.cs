using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockManagementSystem.Models
{
    public class Sale
    {
        public int Id { get; set; }

        public DateTime SaleDate { get; set; } = DateTime.Now;

        // Bir satış birden fazla ürün içerebilir (çoktan çoğa ilişki)
        public ICollection<SaleItem> SaleItems { get; set; }
    }
}
