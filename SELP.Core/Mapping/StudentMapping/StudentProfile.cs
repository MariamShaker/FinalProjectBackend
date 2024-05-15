using AutoMapper;
using SELP.Core.Features.Students.Commands.Models;
using SELP.Core.Features.Students.Queries.Results;
using SELP.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Mapping.StudentMapping
{
    public class StudentProfile:Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, GetStudentListResponse>();
            CreateMap<Student, GetSingleStudentResponse>();
            CreateMap<AddStudentCommand, Student>()
                .ForMember(dest => dest.ImageUrl, opt => opt.Ignore());
            CreateMap<EditStudentCommand, Student>()
                .ForMember(dest => dest.StudID, opt => opt.Ignore());

        }
    }
}
