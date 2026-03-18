using System.ComponentModel.DataAnnotations;

namespace Polifood.Models
{
    public class Product
    {
        [Key]
        public Guid product_id { get; set; } = Guid.NewGuid();

        [Required]
        public string product_name { get; set; }

        [MinLength(10)]
        public string product_description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El valor debe ser positivo")]
        public int product_price { get; set; }

     
        public string product_image { get; set; }

        public int is_active { get; set; }

        public bool is_available { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El valor debe ser positivo")]
        public int prepTimeMinutes { get; set; }

    }
}
