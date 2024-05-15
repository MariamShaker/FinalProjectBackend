using Microsoft.EntityFrameworkCore;
using SELP.Data.Entities;
using SELP.Infrastructur.Abstract;
using SELP.Infrastructur.Data;
using SELP.Infrastructur.InfrastructurBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Infrastructur.Repository
{
    public class SubjectRepository : GenericRepositoryAsync<Subject>,ISubjectRepository
    {
        #region Fields and properities
        private DbSet<Subject> _subjects {  get; set; }
        #endregion

        #region constructor
        public SubjectRepository(ApplicationDBContext dBContext):base(dBContext)
        {
            _subjects= dBContext.Set<Subject>();
        }
        #endregion

        #region handel fun
        public async Task<Subject> GetByIdWithInstructors(int Id)
        {
            return await _dbContext.subjects
                .Include(e => e.Ins_Subjects)
                .ThenInclude(i => i.instructor)
                .FirstOrDefaultAsync(c => c.SubID == Id);

            }

            public async Task<Subject> GetByIdWithStudents(int Id)
        {
            return await _dbContext.subjects
                .Include(e => e.SubjectStudent)
                .ThenInclude(s => s.student)
                .FirstOrDefaultAsync(c => c.SubID == Id);
        }


        public async Task<Subject> GetByIdWithContents(int Id)
        {
            return await _dbContext.subjects
         .Include(e => e.Contents)
         .AsNoTracking()
         .FirstOrDefaultAsync(c => c.SubID == Id);
        }

        #endregion
    }
}
