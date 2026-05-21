using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polifood.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid CartId { get; set; }
        // ← sin [ForeignKey] ni propiedad Cart — solo el Guid es suficiente

        [Required]
        public List<OrderItem> orderItems { get; set; }
        public int is_active { get; set; }
        public OrderStatus status { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El valor debe ser positivo")]
        public decimal Total { get; set; }
        public bool IsPaid { get; set; } = false;
        public DateTime? PaymentConfirmedAt { get; set; }
    }
}