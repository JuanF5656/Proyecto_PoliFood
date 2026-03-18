using System.ComponentModel.DataAnnotations;

namespace Polifood.Models.DTOs
{
    public class CartItemDto
    {
        public Guid ProductId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El valor debe ser positivo")]
        public int Quantity { get; set; }
    }

}
