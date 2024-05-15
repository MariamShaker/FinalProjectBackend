using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Data.Entities
{
    public class SubjectStudent
    {

        //public int SubjStudID { get; set; }
        [Key]
        public int StudID { get; set; }
        [Key]
        public int SubID { get; set; }

        public decimal? grade { get; set; }

        [ForeignKey(nameof(StudID))]

        [InverseProperty("SubjectStudents")]
        public virtual Student? student { get; set; }


        [ForeignKey(nameof(SubID))]
        [InverseProperty("SubjectStudent")]
        public virtual Subject? subject { get; set; }

    }
}
