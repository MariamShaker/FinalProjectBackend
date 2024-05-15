using MediatR;
using SELP.Core.Bases;
using SELP.Core.Features.Content.Query.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Content.Query.Models
{
    public class GetContentForEachSubject : IRequest<Response<List<GetContentForEachSubjectResponse>>>
    {
        public int SubId { get; set; }
        public GetContentForEachSubject(int id)
        {
            SubId = id;
        }
    }
}
