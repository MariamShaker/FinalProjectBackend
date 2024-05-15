using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Data.Entities
{
    public class Instructor
    {
        public Instructor()
        {
            In_subjects = new HashSet<Ins_Subject>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InsId {get;set;}

        [StringLength(500)]
        public string FirstName { get; set; }

        [StringLength(500)]
        public string LastName { get; set; }

        [StringLength(500)]
        public string? position { get; set; }

        [StringLength(11)]
        public string? phone { get; set; }

        [StringLength(500)]
        public string Email { get; set; }
        public string? ImageUrl { get; set; }

        [InverseProperty("instructor")]
        public virtual ICollection<Ins_Subject> In_subjects { get; set; }
        

    }
}
