using MediatR;
using SELP.Core.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Content.Command.Models
{
    public class UpdateContentCommand : IRequest<Response<string>>
    {
         public int ContentID { get; set; }

        [Required]
        public string? Name { get; set; }
        
        public string? description { get; set; }
        
        [Required]
        public string? video { get; set; }
        
        [Required]
        public string? pdf { get; set; }
        

        [Required]
        public int? subjectID { get; set; }
    }
}
