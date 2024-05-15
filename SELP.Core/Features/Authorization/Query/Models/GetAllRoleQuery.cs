using MediatR;
using SELP.Core.Bases;
using SELP.Core.Features.AuthenticationUser.Query.Response;
using SELP.Core.Features.Authorization.Query.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Authorization.Query.Models
{
    public class GetAllRoleQuery : IRequest<Response<List<GetAllRolesResponse>>>
    {
    }
}
