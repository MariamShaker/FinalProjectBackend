using MediatR;
using SELP.Core.Bases;
using SELP.Core.Features.AuthenticationUser.Query.Response;
using SELP.Core.Features.Students.Queries.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.AuthenticationUser.Query.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {
        public string ID { get; set; }
        public GetUserByIdQuery(string id)
        {
            ID = id;
        }
    }
}
