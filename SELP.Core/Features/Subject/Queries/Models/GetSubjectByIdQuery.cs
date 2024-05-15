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
     public class GetSubjectByIdQuery : IRequest<Response<GetSubjectByIdResponse>>
    {
        public int Id { get; set; }
        public GetSubjectByIdQuery(int id)
        {
           Id = id;
        }
    }
}
