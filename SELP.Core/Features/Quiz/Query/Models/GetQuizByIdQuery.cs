using MediatR;
using SELP.Core.Bases;

using SELP.Core.Features.Quiz.Query.Response;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Quiz.Query.Models
{
    public class GetQuizByIdQuery : IRequest<Response<GetQuizByIdResponse>>
    {
        public int Id { get; set; }
        public GetQuizByIdQuery(int id)
        {
            Id = id;
        }
    }
}
