using MediatR;
using Microsoft.AspNetCore.Http;
using SELP.Core.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Core.Features.Instructors.Command.Models
{
    public class AddInstructorModel : IRequest<Response<string>>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }


        public string? position { get; set; }


        public string? phone { get; set; }

        [Required]
        public string Email { get; set; }
        public IFormFile? ImageUrl { get; set; }
    }
}
