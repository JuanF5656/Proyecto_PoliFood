using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polifood.Models
{
    public class Admin
    {
        [Key]


        public Guid admin_id { get; set; } = Guid.NewGuid();

        public string name_admin { get; set; }
        public int is_active { get; set; }
        [Required]
        public string IdentityUserId { get; set; } = string.Empty;

        [ForeignKey("IdentityUserId")]
        public IdentityUser? IdentityUser { get; set; }
    }
}
