using Microsoft.AspNetCore.Http;
using SELP.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Service.Abstract
{
    public interface IStudentSevice
    {
        public Task<List<Student>> GetStudentListAsync();
        public Task<Student> GetStudentByIDAsync(int id);
        public Task<String> AddAsync(Student student, IFormFile file);
        public Task<String> EditAsync(Student student, IFormFile file);
        public Task<String> DeleteAsync(Student student);
    }
}
