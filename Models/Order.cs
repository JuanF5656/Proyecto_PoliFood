using System.ComponentModel.DataAnnotations;

namespace Polifood.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Required]
        public List<OrderItem> orderItems { get; set; }
        public OrderStatus status { get; set; }

    }
}
