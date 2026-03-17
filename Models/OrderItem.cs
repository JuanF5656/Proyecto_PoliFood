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

        [Required]
        public Guid product_id { get; set; }
        [ForeignKey("product_id")]
        public Product product { get; set; }
        public int is_active { get; set; }

    }
}
