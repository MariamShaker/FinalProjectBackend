using AutoMapper;
using SELP.Core.Features.AuthenticationUser.Commands.Models;
using System;
using SELP.Data.Entities.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SELP.Core.Features.AuthenticationUser.Query.Response;
using SELP.Data.Entities;

namespace SELP.Core.Mapping.AuthenticationUserMapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<AddUserCommand, User>();
            //.ForMember(dest => dest.FirstName, opt => opt.MapFrom(opt => opt.FirstName))
            //.ForMember(dest=>dest.FirstName ,opt=>opt.MapFrom(opt=>opt.FirstName))
            //.ForMember(dest=>dest.LastName ,opt=>opt.MapFrom(opt=>opt.LastName))
            //.ForMember(dest=>dest.Email ,opt=>opt.MapFrom(opt=>opt.Email))
            //.ForMember(dest=>dest.PhoneNumber ,opt=>opt.MapFrom(opt=>opt.PhoneNumber))
            CreateMap<User, GetAllUserResponse>();
            //.ForMember(dest => dest.Password, opt => opt.MapFrom(opt => opt.PasswordHash));
            CreateMap<User, GetUserByIdResponse>().ReverseMap();
            CreateMap<UpdateUserCommand, User>();
        }
    }
}
