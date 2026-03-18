using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polifood.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid CartId { get; set; }
        [ForeignKey("CartId")]

        [Required]
        public List<OrderItem> orderItems { get; set; }
        public int is_active { get; set; }

        public OrderStatus status { get; set; }
        public decimal Total { get; set; }
        public bool IsPaid { get; set; } = false;
        public DateTime? PaymentConfirmedAt { get; set; }


    }

}