using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Instructors.Queries.Response
{
    public class GetInstructorListResponse
    {
        public int InsId { get; set; }

        public string? FirstName { get; set; }


        public string? LastName { get; set; }


        public string? position { get; set; }


        public string? phone { get; set; }


        public string? Email { get; set; }
        public string? ImageUrl { get; set; }
        public List<SubjectsForEachInstructor>? subjectsForEachInstructors { get; set; }

        
    }
    public class SubjectsForEachInstructor

    {
        public string? SubjectName { get; set; }
    }
}
