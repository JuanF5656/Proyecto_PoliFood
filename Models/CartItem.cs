using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polifood.Models
{
    public class CartItem
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Required]

        public Guid ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El valor debe ser positivo")]
        public int Quantity { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "El valor debe ser positivo")]
        public decimal UnitPrice { get; set; } 
    }

}
