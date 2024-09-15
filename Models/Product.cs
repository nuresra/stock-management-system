using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace StockManagementSystem.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Barcode { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        // Her ürünün bir satışa ait olma zorunluluğu yok
        public ICollection<Sale>? Sales { get; set; }

    }

}
