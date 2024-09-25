using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace StockManagementSystem.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Barkod 13 karakter olmalıdır.")]
        public string Barcode { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public ICollection<SaleItem> SaleItems { get; set; }


    }

}
