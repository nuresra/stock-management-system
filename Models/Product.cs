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

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Fiyat sıfırdan büyük olmalıdır.")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stok miktarı negatif olamaz.")]
        public int StockQuantity { get; set; }


        public ICollection<SaleItem>? SaleItems { get; set; } // null olabilir


    }

}
