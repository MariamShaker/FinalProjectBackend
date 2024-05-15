using MediatR;
using SELP.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Authorization.Command.Models
{
    public class UpdateUserClaims : IRequest<Response<string>>
    {
        public string UserId { get; set; }
        public List<UserClaims> Claims { get; set; }

    }
    // top level class cannot be any thing other internal or public
    public class UserClaims
    {
        public string Type { get; set; }
        public bool Value { get; set; }
    }
}
