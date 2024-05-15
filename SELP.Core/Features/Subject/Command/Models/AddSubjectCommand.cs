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
    public class AddSubjectCommand : IRequest<Response<string>>
    {
        [Required]
        public string? SubjectName { get; set; }

        public string? SubjectDescription { get; set; }

        public int? Period { get; set; }
    }
}
