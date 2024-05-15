using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Data.Entities
{
    public class Quiz
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int QuizID {  get; set; }
        public string? Name { get; set;}
        public string? Question { get; set;}
        public string? CorrectAnswer { get; set;}
        public string? Ans1 { get; set;}
        public string? Ans2 { get; set;}
        public string? Ans3 { get; set;}
        public string? Ans4 { get; set;}
        public int ContentID { get; set; }


        [ForeignKey(nameof(ContentID))]
        [InverseProperty("quizzes")]
        public Content content { get; set; }
    }
}
