using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Data.Entities
{
    public class Subject
    {
        public Subject() { 
            SubjectStudent  = new HashSet<SubjectStudent>();
            Ins_Subjects=new HashSet<Ins_Subject>();
            Contents = new HashSet<Content>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubID { get; set; }
        public string? SubjectName { get; set; }

        public string? SubjectDescription { get; set; }

        public int? Period { get; set; }


        [InverseProperty("subject")]
        public virtual  ICollection<SubjectStudent> SubjectStudent { get; set; }

       [InverseProperty("subject")]
        public virtual  ICollection<Ins_Subject> Ins_Subjects { get; set; }


        [InverseProperty("Subject")]
        public virtual  ICollection<Content> Contents{ get; set; }


    
    }
}
