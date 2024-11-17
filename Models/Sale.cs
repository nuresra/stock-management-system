using System;
using System.Collections.Generic;

namespace StockManagementSystem.Models
{
    public class Sale
    {
        public int Id { get; set; }  // Satışın benzersiz ID'si

        public DateTime SaleDate { get; set; } = DateTime.Now;  // Satışın gerçekleştiği tarih ve saat

        // Bir satışın birden fazla ürün içerebileceğini belirten ilişki (İlişkiyi tanımlıyoruz)
        public ICollection<SaleItem> SaleItems { get; set; }
    }
}
