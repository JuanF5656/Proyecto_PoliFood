using System.ComponentModel.DataAnnotations;

namespace Polifood.Models
{
    public class OrderItem
    {
        [Key]
        public Guid orderItem_id { get; set; } = Guid.NewGuid();

        [Required]
        public Product product { get; set; } = new Product();
        public int is_active { get; set; }

    }
}
