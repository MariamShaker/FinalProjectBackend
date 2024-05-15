using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Content.Query.Response
{
    public class GetAllContentResponse
    {
        public int ContentID { get; set; }
        public string? Name { get; set; }
        public string? description { get; set; }
        public string? video { get; set; }
        public string? pdf { get; set; }
        public int? subjectID { get; set; }
    }
}
