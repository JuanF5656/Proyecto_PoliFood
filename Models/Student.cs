using System.ComponentModel.DataAnnotations;

namespace Polifood.Models
{
    public class Student
    {
        [Key]


        public Guid student_id { get; set; } = Guid.NewGuid();

        public string name_student { get; set; }
        public int is_active { get; set; }
    }
}
