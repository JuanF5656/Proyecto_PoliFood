using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polifood.Models
{
    public class Store
    {
        [Key]
        public Guid store_id { get; set; } = Guid.NewGuid();
        public string store_name { get; set; }

        public string categories { get; set; }
        [Required]
        public Guid product_id { get; set; }

        [ForeignKey("productId")]
        public Product product { get; set; }

        public int is_active { get; set; }

    }
}
