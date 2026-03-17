using System.ComponentModel.DataAnnotations;

namespace Polifood.Models
{
    public class Vendor
    {
        [Key]


        public Guid vendor_id { get; set; } = Guid.NewGuid();

        public string vendor_name { get; set; }
        public int is_active { get; set; }
        public Store store {  get; set; }
    }
}
