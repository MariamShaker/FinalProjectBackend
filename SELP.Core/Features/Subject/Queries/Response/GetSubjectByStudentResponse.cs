using SELP.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Subject.Queries.Response
{
    public class GetSubjectByStudentResponse
    {
        public string? SubjectName { get; set; }
        public decimal? grade {  get; set; } 
    }
}
