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
    public class InstructorServices : IInstructorServices
    {
        #region fields
        private IInstructorRepository _instructorRepository;
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        #endregion

        #region constructor
        public InstructorServices(IInstructorRepository instructorRepository, IFileService fileService, IHttpContextAccessor httpContextAccessor)
        {
            _instructorRepository=instructorRepository;
            _fileService=fileService;
            _httpContextAccessor=httpContextAccessor;
        }
        #endregion

        #region handle fun
        public async Task<Instructor> GetInstructorById(int id)
        {
          var instructor= await  _instructorRepository.GetByIdAsync(id);
            return instructor;
        }
        public async Task<List<Instructor>> InstructorListAsync()
        {
            var instructor = await _instructorRepository.GetInstructorListAsync();
            return instructor;
        }
        public async Task<string> AddInstructor(Instructor instructor, IFormFile file)
        {
            //check if the email is exist or not
            var InstructorResult = _instructorRepository.GetTableNoTracking()
                .Where(x => x.Email.Equals(instructor.Email)).FirstOrDefault();

            if (InstructorResult != null)
            {
                return "Exist";
            }
            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;
            var imageUrl = await _fileService.UploadImage("Instructor", file);
            switch (imageUrl)
            {
                case "NoImage": return "NoImage";
                case "FailedToUploadImage": return "FailedToUploadImage";
            }
            instructor.ImageUrl = baseUrl + imageUrl;
            try
            {
                await _instructorRepository.AddAsync(instructor);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInAdd";
            }
           
           
        }
        public async Task<string> UpdateInstructor(Instructor instructor, IFormFile file)
        {
            var context = _httpContextAccessor.HttpContext.Request;
            var baseUrl = context.Scheme + "://" + context.Host;
            var imageUrl = await _fileService.UploadImage("Instructor", file);
            switch (imageUrl)
            {
                case "NoImage": return "NoImage";
                case "FailedToUploadImage": return "FailedToUploadImage";
            }
            instructor.ImageUrl = baseUrl + imageUrl;
            try
            {
                await _instructorRepository.UpdateAsync(instructor);
                return "Success";
            }
            catch (Exception)
            {
                return "FailedInAdd";
            }
          
          
        }
        //delete 
        public async Task<string> DeleteInstructor(Instructor instructor)
        {
            var truns = _instructorRepository.BeginTransaction();
            try
            {
                await _instructorRepository.DeleteAsync(instructor);
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
#region fields
#endregion

#region constructor
#endregion

#region handle fun
#endregion