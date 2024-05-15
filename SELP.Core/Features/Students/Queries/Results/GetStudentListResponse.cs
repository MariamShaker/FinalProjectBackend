using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Students.Queries.Results
{
    public class GetStudentListResponse
    {
        public int StudID { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? phone { get; set; }

        public string? Email { get; set; }
        public string? ImageUrl { get; set; }

    }
}
