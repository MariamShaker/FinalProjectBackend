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
    public class ResultRepository : GenericRepositoryAsync<Result>, IResultRepository
    {
        #region Fields and properities
        private DbSet<Result> _result { get; set; }
        #endregion

        #region constructor
        public ResultRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _result = dBContext.Set<Result>();
        }
        #endregion

        #region handel fun
        #endregion
    }
}
