using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SELP.Core.Bases;
using SELP.Core.Features.AuthenticationUser.Query.Models;
using SELP.Core.Features.AuthenticationUser.Query.Response;
using SELP.Core.Features.Quiz.Query.Models;
using SELP.Core.Features.Quiz.Query.Response;
using SELP.Core.Features.Students.Queries.Models;
using SELP.Core.Features.Students.Queries.Results;
using SELP.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.AuthenticationUser.Query.Handler
{
    public class UserQueryHandler : ResponseHandler,
                 IRequestHandler<GetAllUserQuery, Response<List<GetAllUserResponse>>>,
        IRequestHandler<GetUserByIdQuery, Response<GetUserByIdResponse>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        #region Fields
        #endregion
        #region constructor
        public UserQueryHandler(IMapper mapper,
                                  UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }


        #endregion
        #region Handle Fun
        public async Task<Response<List<GetAllUserResponse>>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.AsQueryable();
            var resultMapper = _mapper.Map<List<GetAllUserResponse>>(users);
            return Success(resultMapper);
        }



       

        public async Task<Response<GetUserByIdResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            //var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id==request.Id);
            var user = await _userManager.FindByIdAsync(request.ID.ToString());
            if (user == null) return NotFound<GetUserByIdResponse>("Not Found");
            var result = _mapper.Map<GetUserByIdResponse>(user);
            return Success(result);
        }
        #endregion

    }
}
