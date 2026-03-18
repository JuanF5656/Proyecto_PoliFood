using System.ComponentModel.DataAnnotations;

namespace Polifood.Models.DTOs
{
    public class CartItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }

}
