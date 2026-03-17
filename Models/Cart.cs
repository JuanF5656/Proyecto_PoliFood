using System.ComponentModel.DataAnnotations;

namespace Polifood.Models
{
    public class Cart
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<Product> products { get; set; } = new List<Product>();
        public int is_active { get; set; }
    }
}
