using Microsoft.EntityFrameworkCore;
using SELP.Infrustructure.Abstracts;

using SELP.Infrastructur.InfrastructurBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SELP.Data.Entites.Identity;
using SELP.Infrastructur.Data;

namespace SELP.Infrustructure.Repositories
{
	public class RefreshTokenRepository:GenericRepositoryAsync<UserRefreshToken>,IRefreshTokenRepository
	{
		#region Fields
		private readonly DbSet<UserRefreshToken> _userRefreshToken;
		#endregion
		#region Constructor
		public RefreshTokenRepository(ApplicationDBContext context) : base(context)
		{
			_userRefreshToken = context.Set<UserRefreshToken>();
		}
		#endregion
		#region Handle Function

		#endregion
	}
}
