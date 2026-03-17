using System.ComponentModel.DataAnnotations;

namespace Polifood.Models
{
    public class Store
    {
        [Key]
        public Guid store_id { get; set; } = Guid.NewGuid();
        public string store_name { get; set; }

        public string categories { get; set; }
        public Product product { get; set; } = new Product();

        public int is_active { get; set; }

    }
}
