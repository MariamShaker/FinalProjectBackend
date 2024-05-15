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
    public class InstructorRepository : GenericRepositoryAsync<Instructor>, IInstructorRepository
    {
        #region Fields and properities
        private DbSet<Instructor> _instructor { get; set; }
        #endregion

        #region constructor
        public InstructorRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _instructor = dBContext.Set<Instructor>();
        }
        #endregion

        #region handel fun
        public async Task<List<Instructor>> GetInstructorListAsync()
        {
            return await _instructor.ToListAsync();
        }
        #endregion
    }
}
