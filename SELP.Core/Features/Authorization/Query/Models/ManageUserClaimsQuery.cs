using MediatR;
using SELP.Core.Bases;
using SchoolProject.Data.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SELP.Core.Features.Authorization.Query.Response;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
    public class ManageUserClaimsQuery:IRequest<Response<ManageUserClaimsResponse>>
    {
        public string UserId { get; set; }
        public ManageUserClaimsQuery(string Id)
        { 
            UserId = Id;
        }
    }
}
