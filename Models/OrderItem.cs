using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polifood.Models
{
    public class OrderItem
    {
        [Key]
        public Guid orderItem_id { get; set; } = Guid.NewGuid();
        [Required]
        public Guid OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order order { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El valor debe ser positivo")]
        public int Quantity { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El valor debe ser positivo")]
        public decimal UnitPrice { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El valor debe ser positivo")]
        public decimal Subtotal { get; set; }

        [Required]
        public Guid product_id { get; set; }
        [ForeignKey("product_id")]
        public Product product { get; set; }
        public int is_active { get; set; }

    }
}