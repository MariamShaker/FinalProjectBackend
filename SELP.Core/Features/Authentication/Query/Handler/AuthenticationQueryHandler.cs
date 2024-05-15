using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Results;
using SELP.Core.Bases;
using SELP.Core.Features.Authentication.Command.Models;
using SELP.Core.Features.Authentication.Query.Models;
using SELP.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace SELP.Core.Features.Authentication.Query.Handler
{
    public class AuthenticationQueryHandler : ResponseHandler,
        IRequestHandler<ResetPasswordQuery, Response<string>>
    {
        #region fields
        private readonly UserManager<User> _userManager;
        #endregion
        #region constructor
        public AuthenticationQueryHandler(UserManager<User> userManager)
        {
            
            _userManager = userManager;
        }


        #endregion
        #region action
        public async Task<Response<string>> Handle(ResetPasswordQuery request, CancellationToken cancellationToken)
        {
            //Get User
            //user
            var user = await _userManager.FindByEmailAsync(request.Email);
            //user not Exist => not found
            if (user == null)
                return BadRequest<string>("UserNotFound");
            //Decrept Code From Database User Code
            var userCode = user.ResetCode;
            //Equal With Code
            if (userCode == request.ResetCode) return Success("Success");
            return BadRequest<string>("Failed");
        }
        #endregion


    }
}
