using MediatR;
using SELP.Core.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Subject.Command.Models
{
    public class UpdateSubjectCommand : IRequest<Response<string>>
    {
        public int SubID { get; set; }
        [Required]
        public string? SubjectName { get; set; }
        [Required]
        public string? SubjectDescription { get; set; }
        [Required]
        public int? Period { get; set; }
    }
}
