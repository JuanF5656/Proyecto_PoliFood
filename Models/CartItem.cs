using System.ComponentModel.DataAnnotations;

namespace Polifood.Models
{
    public class CartItem
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid ProductId { get; set; }
        public Product Product { get; set; }  

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; } 
    }

}
