using MediatR;
using Microsoft.AspNetCore.Http;
using SELP.Core.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Content.Command.Models
{
    public class AddContentCommand : IRequest<Response<string>>
    {
        // public int ContentID { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? description { get; set; }
        public IFormFile? video { get; set; }
        public IFormFile? pdf { get; set; }
        public int? subjectID { get; set; }
    }
}
