using System.ComponentModel.DataAnnotations;

namespace Polifood.Models
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<CartItem> items { get; set; } = new List<CartItem>();
        public int is_active { get; set; }
    }
}
