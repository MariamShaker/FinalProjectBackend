using MediatR;
using SELP.Core.Bases;
using SELP.Core.Features.Subject.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Subject.Queries.Models
{
    public class GetSubjectByInstructorQuery : IRequest<Response<List<GetSubjectByInstructorResponse>>>
    {
        public int InstrucotId { get; set; }
        public GetSubjectByInstructorQuery(int id)
        {
            InstrucotId = id;
        }
    }
}
