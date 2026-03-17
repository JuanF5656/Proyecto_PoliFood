using System.ComponentModel.DataAnnotations;

namespace Polifood.Models
{
    public class Store
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string categories { get; set; }

    }
}
