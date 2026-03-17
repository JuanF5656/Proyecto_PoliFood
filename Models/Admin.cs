using System.ComponentModel.DataAnnotations;

namespace Polifood.Models
{
    public class Admin
    {
        [Key]


        public Guid admin_id { get; set; } = Guid.NewGuid();

        public string name_admin { get; set; }
        public int is_active { get; set; }
    }
}
