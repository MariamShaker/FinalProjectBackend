using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Data.Entities
{
    public class Student
    {
        public Student()
        {
            SubjectStudents = new HashSet<SubjectStudent>();
            Results = new HashSet<Result>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudID { get; set; }

        [StringLength(500)]
        public string? FirstName { get; set; }

        [StringLength(500)] 
        public string? LastName { get; set; }

        [StringLength(11)]
        public string? phone { get; set; }

        [StringLength(500)]
        public string Email { get; set; }
        public string? ImageUrl { get; set; }

        [InverseProperty("student")]
        public virtual ICollection<SubjectStudent> SubjectStudents { get; set; }
        [InverseProperty("student")]
        public virtual ICollection<Result> Results{ get; set; }

    }
}
