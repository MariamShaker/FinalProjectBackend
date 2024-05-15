using MediatR;
using SELP.Core.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Authentication.Query.Models
{
    public class ResetPasswordQuery : IRequest<Response<string>>
    {
        public string ResetCode { get; set; }
        public string Email { get; set; }
    }
}
