using MediatR;
using SELP.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Authorization.Command.Models
{
    public class EditRoleCommand : IRequest<Response<string>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        
    }
}
