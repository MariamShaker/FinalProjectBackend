using SELP.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Service.Abstract
{
    public interface ISubjectService
    {
        public Task<String> AddSubject(Subject subject);
        public Task<String> DeleteSubject(Subject subject);
        public Task<String> EditSubjectAsync(Subject subject);
        public Task<Subject> GetSubjectByIDAsync(int id);
        public Task<List<Subject>> GetAllSubjectAsync();


        public Task<List<Subject>>? GetSubjectsByStudentAsync(int id);
        //content
        public Task<List<Subject>>? GetSubjectsByContentsAsync(int id);





        //public Task<string> AddStudentToSubjectAsync(int StudId, int SubId, decimal grade);
        //public Task<string> AddStudentToSubjectAsync(int StudId, int SubId);


        public Task<List<Subject>>? GetSubjectsByInstructorAsync(int id);
        public Task<string> AddInstructorToSubjectAsync(int InstructorId, int SubId);
        public Task<string> RemoveInstructorFromSubjectAsync(int InstructorId, int SubId);

        //content
       // public Task<string> AddContentToSubjectAsync(int ContentId, string contentName, int SubId);



        public Task<string> AddStudentToSubjectAsync(int studentId, int subjectId, decimal? grade);
        public Task<string> RemoveStudentFromSubjectAsync(int StudId, int SubId);
    }
}
