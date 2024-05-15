using AutoMapper;
using SELP.Core.Features.Content.Command.Models;
using SELP.Core.Features.Content.Query.Response;
using SELP.Core.Features.Instructors.Queries.Response;
using SELP.Core.Features.Students.Commands.Models;
using SELP.Core.Features.Students.Queries.Results;
using SELP.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Mapping.ContentMapping
{
    public class ContentProfile:Profile
    {
        public ContentProfile()
        {
            CreateMap<Content, GetAllContentResponse>().ReverseMap();
            CreateMap<Content, GetContentByIdResponse>().ReverseMap();
            CreateMap<AddContentCommand, Content>();
            CreateMap<UpdateContentCommand, Content>()
              .ForMember(dest => dest.ContentID, opt => opt.Ignore());
             CreateMap<Content, GetContentForEachSubjectResponse>();
        }
    }
}
