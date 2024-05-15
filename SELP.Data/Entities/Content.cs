using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Data.Entities
{
    public class Content
    {
        public Content()
        {
            quizzes = new HashSet<Quiz>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContentID { get; set; }
        public string Name { get; set; }
        public string? description { get; set; }
        public string? video   { get; set; }
        public string? pdf   { get; set; }
        public int subjectID {  get; set; }

        [ForeignKey("subjectID")]
        [InverseProperty("Contents")]
        public virtual Subject? Subject { get; set; }

        [InverseProperty("content")]
        public virtual ICollection<Quiz> quizzes{ get; set; }

    }
}
