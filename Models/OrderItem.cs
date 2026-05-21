using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Polifood.Models
{
    public class OrderItem
    {
        [Key]
        public Guid orderItem_id { get; set; } = Guid.NewGuid();

        [Required]
        public Guid OrderId { get; set; }

        [ForeignKey("OrderId")]
        [JsonIgnore]  // ← evita ciclo Order → OrderItem → Order
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
        [JsonIgnore]  // ← evita ciclo OrderItem → Product → OrderItem
        public Product product { get; set; }

        public int is_active { get; set; }
    }
}