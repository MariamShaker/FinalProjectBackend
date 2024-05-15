using Microsoft.AspNetCore.Http;
using SELP.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Service.Abstract
{
    public interface IInstructorServices
    {
        public Task<List<Instructor>> InstructorListAsync();
        public Task<Instructor> GetInstructorById(int id);
        public Task<string> AddInstructor(Instructor instructor, IFormFile file);
        public Task<string> UpdateInstructor(Instructor instructor, IFormFile file);
        public Task<string> DeleteInstructor(Instructor instructor);

    }
}
