using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Core.Features.ApplicationUser.Command.Models;
using SELP.Core.Bases;
using SELP.Core.Features.AuthenticationUser.Commands.Models;
using SELP.Data.Entities;
using SELP.Data.Entities.Identity;
using SELP.Infrastructur.Data;
using SELP.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.AuthenticationUser.Commands.Handler
{
    public class UserCommandHandler : ResponseHandler,
        IRequestHandler<AddUserCommand, Response<string>>,
          IRequestHandler<UpdateUserCommand, Response<string>>,
         IRequestHandler<DeleteUserCommand, Response<string>>,
         IRequestHandler<ChangePasswordCommand, Response<string>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly UserManager <User> _userManager ;
        private readonly ApplicationDBContext _dBContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailService _emailsService;
        private readonly IUrlHelper _urlHelper;
        #endregion
        #region constructor
        public UserCommandHandler(IMapper mapper , UserManager<User> userManager,
            ApplicationDBContext dBContext, IHttpContextAccessor httpContextAccessor, 
            IEmailService emailsService, IUrlHelper urlHelper)
        {
            _mapper = mapper;
            _userManager = userManager;
            _dBContext = dBContext;
            _httpContextAccessor = httpContextAccessor;
            _emailsService = emailsService;
            this._urlHelper = urlHelper;
        }
        #endregion
        #region Handle Fun
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var trans = await _dBContext.Database.BeginTransactionAsync();
            try
            {


                            //if email is exist
                            var user = await  _userManager.FindByEmailAsync(request.Email);
                        //msg="email is exist"
                        if (user != null) return BadRequest<string>("Email Is Exist");

                        //if username is exist
                        var userName = await _userManager.FindByNameAsync(request.UserName);
                        //msg="userName is exist"
                        if (userName != null) return BadRequest<string>("userName Is Exist");

                        //mapping
                        var identityUser = _mapper.Map<User>(request);
                        //create
                        var createResult = await _userManager.CreateAsync(identityUser,request.Password);

                        //faild => msgfaild
                        if (!createResult.Succeeded)
                        {
                            var errorDescriptions = string.Join(",", createResult.Errors.Select(error => error.Description));
                            return BadRequest<string>(errorDescriptions);
                        }
                        //add user to role User
                        // Check if the request includes a valid role selection
                        if (!string.IsNullOrEmpty(request.UserRole) && (request.UserRole == "Student" || request.UserRole == "Teacher"
                            || request.UserRole == "Teacher"))
                        {
                            // Add user to the selected role
                            await _userManager.AddToRoleAsync(identityUser, request.UserRole);
                            // If the role is "Student", add data to the student table
                            if (request.UserRole == "Student")
                            {
                                // Create a Student entity and populate it with data from the request
                                var student = new Student
                                {
                                    FirstName = identityUser.FirstName,
                                    LastName = identityUser.LastName,
                                    Email = identityUser.Email,
                                    phone = identityUser.PhoneNumber,
                                    // Assuming other properties of the Student entity are set here
                                };

                                // Add the student to the context and save changes
                                _dBContext.students.Add(student);
                                await _dBContext.SaveChangesAsync();
                            }
                            // If the role is "Teacher", add data to the student table
                            if (request.UserRole == "Teacher")
                            {
                                // Create a Student entity and populate it with data from the request
                                var instructor = new Instructor
                                {
                                    FirstName = identityUser.FirstName,
                                    LastName = identityUser.LastName,
                                    Email = identityUser.Email,
                                    phone = identityUser.PhoneNumber,
                                    // Assuming other properties of the Student entity are set here
                                };


                                // Add the instructor entity to the DbContext
                                _dBContext.Entry(instructor).State = EntityState.Added;

                                // Save changes to the database
                                await _dBContext.SaveChangesAsync();
                               
                   
                            }
                        }
                        else
                        {
                            // Default role assignment if no role is specified or the specified role is invalid
                            await _userManager.AddToRoleAsync(identityUser, "User");
                        }

                
                //Send Confirm Email
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
                var resquestAccessor = _httpContextAccessor.HttpContext.Request;
                var returnUrl = resquestAccessor.Scheme+"://" +resquestAccessor.Host+ _urlHelper.Action("ConfirmEmail", "Authentication", new { userId = identityUser.Id, code = code });
                var message = $"<h1>Welcome to our website Smart E_learning Platform ^_^</h1>" +
                    $"To Confirm Your Email Click Link: <a href='{returnUrl}'>Press here to Confirm Your Email</a>";
                //$"/Api/V1/Authentication/ConfirmEmail?userId={user.Id}&code={code}";
                
                //message or body
                await _emailsService.SendEmail(identityUser.Email, message, "ConFirm Email");

                await trans.CommitAsync();
                return Success("Success");

            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return BadRequest<string>("Failed");
            }

            //create
            //Success => msgSuccess
           // return Success("Success");

        }

        public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            //check if user is exist
            var oldUser = await _userManager.FindByIdAsync(request.Id.ToString());
            //if Not Exist notfound
            if (oldUser == null) return NotFound<string>();
            //mapping
            var newUser = _mapper.Map(request, oldUser);
            //if username is Exist
            var userByUserName = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == newUser.UserName && x.Id != newUser.Id);
            //username is Exist
            if (userByUserName != null) return BadRequest<string>();
            //update
            var result = await _userManager.UpdateAsync(newUser);
            //result is not success
            if (!result.Succeeded)
            {
                var errorDescriptions = string.Join(",", result.Errors.Select(error => error.Description));
                return BadRequest<string>(errorDescriptions);
            }
            //message
            return Success("Success");
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var User = await _userManager.FindByIdAsync(request.Id.ToString());
            if (User == null) return NotFound<string>();
            var Result = await _userManager.DeleteAsync(User);
            if (!Result.Succeeded)
            {
                var errorDescriptions = string.Join(",", Result.Errors.Select(error => error.Description));
                return BadRequest<string>(errorDescriptions);
            }
            return Deleted<string>();
        }

        public async Task<Response<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            //get user
            //check if user is exist
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            //if Not Exist notfound
            if (user == null) return NotFound<string>();

            //Change User Password
            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            //var user1=await _userManager.HasPasswordAsync(user);
            //await _userManager.RemovePasswordAsync(user);
            //await _userManager.AddPasswordAsync(user, request.NewPassword);

            //result
            if (!result.Succeeded)
            {
                var errorDescriptions = string.Join(",", result.Errors.Select(error => error.Description));
                return BadRequest<string>(errorDescriptions);
            }
            return Success("Success");
        }
        #endregion

    }
}
