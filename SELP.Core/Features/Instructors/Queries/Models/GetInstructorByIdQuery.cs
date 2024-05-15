using MediatR;
using SELP.Core.Bases;
using SELP.Core.Features.Instructors.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Instructors.Queries.Models
{
    public class GetInstructorByIdQuery:IRequest<Response<GetInstructorByIdResponse>>

    {
        public int Id { get; set; }
        public GetInstructorByIdQuery(int id)
        {
            Id = id;
        }
    }
}
