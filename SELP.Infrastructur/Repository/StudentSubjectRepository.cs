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
    public class StudentSubjectRepository : GenericRepositoryAsync<SubjectStudent>, IStudentSubjectRepository
    {
        #region Fields
        private readonly DbSet<SubjectStudent> _StdSubjects;
        #endregion
        #region Constructor
        public StudentSubjectRepository(ApplicationDBContext context) : base(context)
        {
            _StdSubjects = context.Set<SubjectStudent>();
        }
        #endregion
        #region HandleFunctions
        public async Task<SubjectStudent> GetStudentSubject(int StdID, int SubId)
        {
            return await _StdSubjects.FirstOrDefaultAsync(e => e.StudID == StdID && e.SubID == SubId);
        }

        #endregion
    }
}
