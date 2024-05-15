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
    public class GetAllQuizQuery : IRequest<Response<List<GetAllQuizResponse>>>
    {
    }
}
