using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Results;
using SELP.Core.Bases;
using SELP.Core.Features.Authentication.Command.Models;
using SELP.Data.Entities;
using SELP.Data.Entities.Identity;
using SELP.Infrastructur.Data;
using SELP.Service.Abstract;
using SELP.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace SELP.Core.Features.Authentication.Command.Handler
{
    public class AuthCommandHandler : ResponseHandler,
        IRequestHandler<SignInCommand, Response<JwtAuthResult>>,
        IRequestHandler<ComfirmEmail, Response<string>>,
        IRequestHandler<ResetPasswordCommand, Response<string>>,
        IRequestHandler<ConfirmResetPassCommand, Response<string>>
    {

        #region Fields
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthenticationService _authenticationService;
        private readonly ApplicationDBContext _dBContext;
        private readonly IEmailService _emailsService;
        #endregion
        #region Constructor
        public AuthCommandHandler(UserManager<User> userManager,
            SignInManager<User> signInManager,IAuthenticationService authenticationService,
            ApplicationDBContext dBContext, IEmailService emailsService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationService = authenticationService;
            _dBContext = dBContext;
            _emailsService = emailsService;
        }
        #endregion
        #region Handle Fun
        public async Task<Response<JwtAuthResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            //check email is exist
            var user =await  _userManager.FindByEmailAsync(request.Email);
            //Return the email not found
            if (user == null) return BadRequest<JwtAuthResult>("Email Not Exist");

            //try to sign in
            var signInResult =await  _signInManager.CheckPasswordSignInAsync(user, request.Password,false);
            //if email comfim
            if (!user.EmailConfirmed)
            {
                return BadRequest<JwtAuthResult>("Email Not Confirmed, Please comfirm your email! ");
            }


            //
            //if faild retutn pass is wrong
            if (!signInResult.Succeeded)
            {
                return BadRequest<JwtAuthResult>("Password not correct");
            }
            
            //generate token
            var result = await _authenticationService.GetJWTToken(user);

            //return token
            return Success(result);
        }

        public async Task<Response<string>> Handle(ComfirmEmail request, CancellationToken cancellationToken)
        {
            if (request.UserId == null || request.Code == null)
                return BadRequest<string>("ErrorWhenConfirmEmail");
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            var confirmEmail = await _userManager.ConfirmEmailAsync(user, request.Code);
            if (!confirmEmail.Succeeded)
                return BadRequest<string>("ErrorWhenConfirmEmail");
            return Success("Success");
        }

        public async Task<Response<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var trans = await _dBContext.Database.BeginTransactionAsync();
            try
            {
                //user
                var user = await _userManager.FindByEmailAsync(request.Email);
                //user not Exist => not found
                if (user == null)
                    return BadRequest<string>("UserNotFound");
                //Generate Random Number

                //Random generator = new Random();
                //string randomNumber = generator.Next(0, 1000000).ToString("D6");
                var chars = "0123456789";
                var random = new Random();
                var randomNumber = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());

                //update User In Database Code
                user.ResetCode = randomNumber;
                var updateResult = await _userManager.UpdateAsync(user);
                if (!updateResult.Succeeded)
                    return BadRequest<string>("ErrorInUpdateUser");
                var message = "Code To Reset Passsword : " + user.ResetCode;
                //Send Code To  Email 
                await _emailsService.SendEmail(user.Email, message, "Reset Password");
                await trans.CommitAsync();
                return Success("Success");
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return BadRequest<string>("Failed");
            }
        }

        public async Task<Response<string>> Handle(ConfirmResetPassCommand request, CancellationToken cancellationToken)
        {
            var trans = await _dBContext.Database.BeginTransactionAsync();
            try
            {
                //Get User
                var user = await _userManager.FindByEmailAsync(request.Email);
                //user not Exist => not found
                if (user == null)
                    return BadRequest<string>("UserNotFound");
                await _userManager.RemovePasswordAsync(user);
                if (!await _userManager.HasPasswordAsync(user))
                {
                    await _userManager.AddPasswordAsync(user, request.Password);
                }
                await trans.CommitAsync();
                return Success("Success");
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return BadRequest<string>("Failed");
            }
        }
    }
        #endregion

    }

