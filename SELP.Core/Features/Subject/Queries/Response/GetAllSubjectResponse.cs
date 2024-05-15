using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Subject.Queries.Response
{
    public class GetAllSubjectResponse
    {
        public string? SubjectName { get; set; }

        public string? SubjectDescription { get; set; }

        public int? Period { get; set; }

    }
}
