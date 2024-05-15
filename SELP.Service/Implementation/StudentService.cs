using Microsoft.AspNetCore.Http;
using SELP.Data.Entities;
using SELP.Infrastructur.Abstract;
using SELP.Infrastructur.Repository;
using SELP.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Service.Implementation
{
    public class StudentService : IStudentSevice
    {
        #region Fields
        private readonly IStudentRepository _studentRepository;
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region Constructor
        public StudentService(IStudentRepository studentRepository, IFileService fileService, IHttpContextAccessor httpContextAccessor)
        {
          _studentRepository = studentRepository;
            _fileService = fileService;
            _httpContextAccessor = httpContextAccessor;
        }

        
        #endregion

        #region Handle Fun
        public async Task<List<Student>> GetStudentListAsync()
        {
            return await _studentRepository.GetStudentsListAsync();
        }
        public async Task<Student> GetStudentByIDAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return student;
        }
        // add student Function
        public async Task<string> AddAsync(Student student, IFormFile file)
        {
            //check if the name is exist or not
            var studentResult = _studentRepository.GetTableNoTracking()
                .Where(x => x.Email.Equals(student.Email)).FirstOrDefault();
            if (studentResult != null)
            {
                return "Exist";
            }

            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;
            var imageUrl = await _fileService.UploadImage("Students", file);
            switch (imageUrl)
            {
                case "NoImage": return "NoImage";
                case "FailedToUploadImage": return "FailedToUploadImage";
            }
            student.ImageUrl = baseUrl + imageUrl;
            try
            {
                await _studentRepository.AddAsync(student);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInAdd";
            }


            
        }

        public async Task<string> EditAsync(Student student, IFormFile file)
        {
            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;
            var imageUrl = await _fileService.UploadImage("Students", file);
            switch (imageUrl)
            {
                case "NoImage": return "NoImage";
                case "FailedToUploadImage": return "FailedToUploadImage";
            }
            student.ImageUrl = baseUrl + imageUrl;
            try
            {
                await _studentRepository.UpdateAsync(student);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInAdd";
            }
            
           
        }

        public async Task<string> DeleteAsync(Student student)
        {
            var truns =  _studentRepository.BeginTransaction();
            try
            {
                await _studentRepository.DeleteAsync(student);
               await truns.CommitAsync();
                return "Success";
            }
            catch
            {
                await truns.RollbackAsync();
                return "Failds";
            }
            
        }


        #endregion

    }
}
