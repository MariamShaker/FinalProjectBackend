using MediatR;
using SELP.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Subject.Command.Models
{
    public class DeleteSubjectCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteSubjectCommand(int id)
        {
            Id = id;
        }
    }
}
