using System;
using System.ComponentModel.DataAnnotations;

namespace Repository_Layer.Entity
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Product name is required")]
        [StringLength(500, ErrorMessage = "Name cannot exceed 500 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be positive")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Stock quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity cannot be negative")]
        public int StockQuantity { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [StringLength(50)]
        public string Category { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
