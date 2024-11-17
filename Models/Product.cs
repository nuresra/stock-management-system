using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace StockManagementSystem.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "Barkod 13 karakter olmalıdır.")]
        public string Barcode { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Fiyat sıfırdan büyük olmalıdır.")]
        public decimal Price { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Stok miktarı negatif olamaz.")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "Kategori zorunludur.")]
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public ICollection<SaleItem>? SaleItems { get; set; } // null olabilir


    }

}
