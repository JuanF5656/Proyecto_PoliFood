using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polifood.Models
{
    public class Vendor
    {
        [Key]


        public Guid vendor_id { get; set; } = Guid.NewGuid();

        public string vendor_name { get; set; }
        public int is_active { get; set; }
        public Store store {  get; set; }
        
        [Required]
        public string IdentityUserId { get; set; } = string.Empty;

        [ForeignKey("IdentityUserId")]
        public IdentityUser? IdentityUser { get; set; }
    }
}
