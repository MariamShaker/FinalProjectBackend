using MediatR;
using SELP.Core.Bases;
using SELP.Core.Features.Authorization.Command.Models;
using SELP.Core.Features.Email.Command.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Email.Command.Handler
{
    public class EmailHandler : ResponseHandler,
           IRequestHandler<SendEmailCommand, Response<string>>
    {
        #region Fields
        #endregion
        #region constructor
        public EmailHandler()
        {
            
        }


        #endregion
        #region Actions
        public Task<Response<string>> Handle(SendEmailCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
