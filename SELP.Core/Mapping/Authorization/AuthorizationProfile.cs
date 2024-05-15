using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SELP.Core.Features.AuthenticationUser.Commands.Models;
using SELP.Core.Features.AuthenticationUser.Query.Response;
using SELP.Core.Features.Authorization.Query.Response;
using SELP.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Mapping.Authorization
{
    public class AuthorizationProfile : Profile
    {
        public AuthorizationProfile()
        {
           // CreateMap<AddUserCommand, User>();
            //.ForMember(dest => dest.FirstName, opt => opt.MapFrom(opt => opt.FirstName))
            //.ForMember(dest=>dest.FirstName ,opt=>opt.MapFrom(opt=>opt.FirstName))
            //.ForMember(dest=>dest.LastName ,opt=>opt.MapFrom(opt=>opt.LastName))
            //.ForMember(dest=>dest.Email ,opt=>opt.MapFrom(opt=>opt.Email))
            //.ForMember(dest=>dest.PhoneNumber ,opt=>opt.MapFrom(opt=>opt.PhoneNumber))
            CreateMap<IdentityRole, GetAllRolesResponse>();
            //.ForMember(dest => dest.Password, opt => opt.MapFrom(opt => opt.PasswordHash));
            CreateMap<IdentityRole, GetRoleByIdResponse>().ReverseMap();
          //  CreateMap<UpdateUserCommand, User>();
        }
    }
}
