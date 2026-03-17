using System.ComponentModel.DataAnnotations;

namespace Polifood.Models
{
    public class Student
    {
        [Key]


        public Guid student_id { get; set; } = Guid.NewGuid();

        public string student_name { get; set; }
        public int is_active { get; set; }
    }
}
