using Microsoft.AspNetCore.Identity;
using Polifood.Models.DTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Polifood.Models
{
    public class Student
    {
        [Key]


        public Guid student_id { get; set; } = Guid.NewGuid();

        public string student_name { get; set; }
        public int is_active { get; set; }
       
        [Required]
        public string IdentityUserId { get; set; } = string.Empty;

        [ForeignKey("IdentityUserId")]
        public IdentityUser? IdentityUser { get; set; }


    }
}
