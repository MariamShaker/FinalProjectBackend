using MediatR;
using SELP.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Instructors.Command.Models
{
    public class DeleteInstructorCommandModel : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteInstructorCommandModel(int Id)
        {
            this.Id = Id;
        }
    }
}
