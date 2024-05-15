using MediatR;
using SELP.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Authentication.Command.Models
{
    public class ResetPasswordCommand:IRequest<Response<string>>
    {
        public string Email { get; set; }
    }
}
