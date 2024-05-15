using Microsoft.EntityFrameworkCore;
using SchoolProject.Infrustructure.Abstracts;
using SELP.Data.Entities;
using SELP.Infrastructur.Data;
using SELP.Infrastructur.InfrastructurBase;

namespace SchoolProject.Infrustructure.Repositories
{
    public class InstructorSubjectRepository : GenericRepositoryAsync<Ins_Subject>, IInstructorSubjectRepository
    {
        #region Fields
        private readonly DbSet<Ins_Subject> _InsSubjects;
        #endregion
        #region Constructor
        public InstructorSubjectRepository(ApplicationDBContext context) : base(context)
        {
            _InsSubjects = context.Set<Ins_Subject>();
        }
        #endregion
        #region HandleFunctions
        public async Task<Ins_Subject> GetInstructorSubject(int InsID, int SubId)
        {
            return await _InsSubjects.FirstOrDefaultAsync(e => e.SubId == SubId && e.InsId == InsID);
        }

        #endregion
    }
}
