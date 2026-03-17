using System.ComponentModel.DataAnnotations;

namespace Polifood.Models
{
    public class Product
    {
        [Key]
        public Guid product_id { get; set; } = Guid.NewGuid();
    
        public string product_name { get; set; }
    
        public string product_description { get; set; }

        public int product_price { get; set; }

     
        public string product_image { get; set; }

        public int is_active { get; set; }

        public bool is_available { get; set; }

        public int prepTimeMinutes { get; set; }

    }
}
