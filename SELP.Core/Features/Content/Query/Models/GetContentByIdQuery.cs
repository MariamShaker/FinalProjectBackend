using MediatR;
using SELP.Core.Bases;
using SELP.Core.Features.Content.Query.Response;
using SELP.Core.Features.Subject.Queries.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Content.Query.Models
{
    public class GetContentByIdQuery : IRequest<Response<GetContentByIdResponse>>
    {
        public int Id { get; set; }
        public GetContentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
