using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Data.Entities
{
    public class Result
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResultID { get; set; }
        public int? Score {get; set; }
        public int? TotlalItem {get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }

        [ForeignKey(nameof(StudentID))]
        [InverseProperty("Results")]
        public Student student { get; set; }


        [ForeignKey(nameof(SubjectID))]
        public Subject subject { get; set; }
    }
}
