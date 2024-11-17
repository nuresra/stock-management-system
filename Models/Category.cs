using System.ComponentModel.DataAnnotations;

namespace StockManagementSystem.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
