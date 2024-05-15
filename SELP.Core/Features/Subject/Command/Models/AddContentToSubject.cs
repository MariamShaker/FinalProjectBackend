using MediatR;
using SELP.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Subject.Command.Models
{
    public class AddContentToSubject : IRequest<Response<string>>
    {
        public int ContentId { get; set; }
        public string ContentName { get; set; }
        public int SubjectId { get; set; }
    }
}
