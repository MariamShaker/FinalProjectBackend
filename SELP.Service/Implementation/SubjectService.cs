using Microsoft.EntityFrameworkCore;
using SchoolProject.Infrustructure.Abstracts;
using SchoolProject.Infrustructure.Repositories;
using SELP.Data.Entities;
using SELP.Infrastructur.Abstract;
using SELP.Infrastructur.Data;
using SELP.Infrastructur.Repository;
using SELP.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Service.Implementation
{
    public class SubjectService : ISubjectService
    {
        #region fields
        private readonly ISubjectRepository _subjectRepository;
        private readonly ApplicationDBContext _context;
        private readonly IInstructorRepository _instructorRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentSubjectRepository _studentSubjectRepository;
        private readonly IContentRepository _contentRepository;

        //private readonly IInstructorSubjectRepository _instructorSubjectRepository;





        #endregion
        #region constructor
        public SubjectService(ISubjectRepository subjectRepository, ApplicationDBContext context,
            IInstructorRepository instructorRepository,
            IStudentRepository studentRepository,
            IStudentSubjectRepository studentSubjectRepository,
            IContentRepository contentRepository
           // IInstructorSubjectRepository instructorSubjectRepository
             )
        {
            _subjectRepository = subjectRepository;
            _context = context;
            _instructorRepository = instructorRepository;
            _studentRepository = studentRepository;
            _studentSubjectRepository = studentSubjectRepository;
            this._contentRepository = contentRepository;
            //   this._instructorSubjectRepository = instructorSubjectRepository;
        }
        #endregion
        #region handle fun
        public async Task<Subject> GetSubjectByIDAsync(int id)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);
            return subject;
        }
        public async Task<List<Subject>> GetAllSubjectAsync()
        {
            var subject = await _subjectRepository.GetTableAsTracking().ToListAsync();
            return subject;
        }

        public async Task<string> AddSubject(Subject subject)
        {
            //check if the name is exist or not
            var subjectResult = _subjectRepository.GetTableNoTracking()
                .Where(x => x.SubjectName.Equals(subject.SubjectName)).FirstOrDefault();
            if (subjectResult != null)
            {
                return "Exist";
            }

            //add student class

            await _subjectRepository.AddAsync(subject);
            return "Success";
        }
        public async Task<string> DeleteSubject(Subject subject)
        {
            var truns = _subjectRepository.BeginTransaction();
            try
            {
                await _subjectRepository.DeleteAsync(subject);
                await truns.CommitAsync();
                return "Success";
            }
            catch
            {
                await truns.RollbackAsync();
                return "Failds";
            }
        }
        public async Task<string> EditSubjectAsync(Subject subject)
        {
            await _subjectRepository.UpdateAsync(subject);
            return "Success";
        }


        public async Task<List<Subject>>? GetSubjectsByInstructorAsync(int id)
        {
            var subjects = await _context.subjects
       .Include(s => s.Ins_Subjects)
       .ThenInclude(i => i.instructor)
       .Where(s => s.Ins_Subjects.Any(ins => ins.InsId == id))
       .ToListAsync();

            return subjects;
        }

        public async Task<List<Subject>>? GetSubjectsByStudentAsync(int id)
        {
            var student = await _context.subjects
       .Include(s => s.SubjectStudent)
       .ThenInclude(i => i.student)
       .Where(s => s.SubjectStudent.Any(ins => ins.StudID == id))
       .ToListAsync();

            return student;
        }
        
        
        
        // get content
        public async Task<List<Subject>>? GetSubjectsByContentsAsync(int id)
        {
            var subjects = await _context.subjects
       .Where(s => s.Contents.Any(c => c.ContentID == id))
       .ToListAsync();

            return subjects;

        }
        
        //public async Task<string> AddContentToSubjectAsync(int ContentId,string contentName, int SubId)
        //{
        //    // GetTheInstructor
        //    var content = await _contentRepository.GetByIdAsync(ContentId);
        //    // Null Checking
        //    if (content == null) return "contentNotFound";
        //    // Get The Class 
        //    var Subject = await _subjectRepository.GetByIdWithContents(SubId);
        //    if (Subject == null) return "SubjectNotFound";
        //    // Check If Exsists
        //    var IsExsist = Subject.Contents.Any(e => e.ContentID == ContentId);
        //    if (IsExsist) return "Already Exsists";
        //    // Add Instructor To Class
        //    var conId = new Content()
        //    { ContentID = content.ContentID, subjectID = Subject.SubID,Name= contentName };
        //    Subject.Contents.Add(conId);

        //    _context.SaveChanges();
        //    return "Success";
        //}








        //public async Task<string> AddStudentToSubjectAsync(int StudId, int SubId)
        //{
        //    // GetTheInstructor
        //    var Student = await _studentRepository.GetByIdAsync(StudId);
        //    // Null Checking
        //    if (Student == null) return "StudentNotFound";
        //    // Get The Class 
        //    var Subject = await _subjectRepository.GetByIdWithStudents(SubId);
        //    if (Subject == null) return "SubjectNotFound";
        //    // Check If Exsists
        //    var IsExsist = Subject.SubjectStudent.Any(e => e.StudID == Student.StudID);
        //    if (IsExsist) return "Already Exsists";
        //    // Add Instructor To Class
        //    var StdSub = new SubjectStudent()
        //    { StudID = Student.StudID, SubID = Subject.SubID };
        //    Subject.SubjectStudent.Add(StdSub);

        //    _context.SaveChanges();
        //    return "Success";
        //}

        public async Task<string> AddInstructorToSubjectAsync(int InstructorId, int SubId)
        {
            // GetTheInstructor
            var instructor = await _instructorRepository.GetByIdAsync(InstructorId);
            // Null Checking
            if (instructor == null) return "InstructorNotFound";
            // Get The Class 
            var Subject = await _subjectRepository.GetByIdWithInstructors(SubId);
            if (Subject == null) return "SubjectNotFound";
            // Check If Exsists
            var IsExsist = Subject.Ins_Subjects.Any(e => e.InsId == InstructorId);
            if (IsExsist) return "Already Exsists";
            // Add Instructor To Class
            var insub = new Ins_Subject()
            { InsId = instructor.InsId, SubId = Subject.SubID };
            Subject.Ins_Subjects.Add(insub);

            _context.SaveChanges();
            return "Success";
        }
        




        public async Task<string> AddStudentToSubjectAsync(int studentId, int subjectId, decimal? grade)
        {
            // GetTheInstructor
            var Student = await _studentRepository.GetByIdAsync(studentId);
            // Null Checking
            if (Student == null) return "StudentNotFound";
            // Get The Class 
            var Subject = await _subjectRepository.GetByIdWithStudents(subjectId);
            if (Subject == null) return "SubjectNotFound";
            // Check If Exsists
            var IsExsist = Subject.SubjectStudent.Any(e => e.StudID == Student.StudID);
            if (IsExsist) return "Already Exsists";
            // Add Instructor To Class
            var StdSub = new SubjectStudent()
            { StudID = Student.StudID, SubID = Subject.SubID , grade=grade};
            Subject.SubjectStudent.Add(StdSub);

            _context.SaveChanges();
            return "Success";
        }
        public async Task<string> RemoveStudentFromSubjectAsync(int StudId, int SubId)
        {
            // GetTheStudent
            var Student = await _studentRepository.GetByIdAsync(StudId);
            // Null Checking
            if (Student == null) return "StudentNotFound";
            // Get The Class 
            var Subject = await _subjectRepository.GetByIdWithStudents(SubId);
            if (Subject == null) return "SubjectNotFound";
            // Check If Exsists
            var IsExsist = Subject.SubjectStudent.Any(e => e.StudID == Student.StudID);
            if (!IsExsist) return "AlreadyNotExsists";
            // Add Instructor To Class
            var StdSub = new SubjectStudent()
            { StudID = Student.StudID, SubID = Subject.SubID };
            var todelete = await _studentSubjectRepository.GetStudentSubject(StdSub.StudID, StdSub.SubID);
            await _studentSubjectRepository.DeleteAsync(todelete);
            _context.SaveChanges();
            return "Success";
        }

        public Task<string> RemoveInstructorFromSubjectAsync(int InstructorId, int SubId)
        {
            throw new NotImplementedException();
        }

        //public async Task<string> RemoveInstructorFromSubjectAsync(int instructorId, int subId)
        //{
        //    // Get the Instructor
        //    var instructor = await _instructorRepository.GetByIdAsync(instructorId);
        //    // Null Checking
        //    if (instructor == null) return "InstructorNotFound";

        //    // Get the Subject 
        //    var subject = await _subjectRepository.GetByIdWithInstructors(subId);
        //    if (subject == null) return "SubjectNotFound";

        //    // Check If Exists
        //    var exists = subject.Ins_Subjects.Any(e => e.InsId == instructor.InsId);
        //    if (!exists) return "AlreadyNotExists";

        //    // Remove Instructor From Subject
        //    var insub = new Ins_Subject() { InsId = instructor.InsId, SubId = subject.SubID };
        //    var toDelete = await _insSubRepository.GetInstructorSubject(insub.InsId, insub.SubId);
        //    if (toDelete != null)
        //    {
        //        await _insSubRepository.DeleteAsync(toDelete);
        //        _context.SaveChanges();
        //        return "Success";
        //    }

        //    // If deletion failed for some reason
        //    return "FailedToDelete";
        //}

        #endregion
    }
}
