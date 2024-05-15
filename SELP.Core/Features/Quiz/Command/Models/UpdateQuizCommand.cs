using MediatR;
using SELP.Core.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Quiz.Command.Models
{
    public class UpdateQuizCommand : IRequest<Response<string>>
    {
         public int QuizID { get; set; }
        
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Question { get; set; }
        [Required]
        public string? CorrectAnswer { get; set; }
        public string? Ans1 { get; set; }
        public string? Ans2 { get; set; }
        public string? Ans3 { get; set; }
        public string? Ans4 { get; set; }
        [Required]
        public int? ContentID { get; set; }
    }
}
