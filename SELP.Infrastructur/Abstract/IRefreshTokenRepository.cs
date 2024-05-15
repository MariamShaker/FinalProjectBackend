using SELP.Data.Entites.Identity;
using SELP.Infrastructur.InfrastructurBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SELP.Infrustructure.Abstracts
{
	public interface IRefreshTokenRepository:IGenericRepositoryAsync<UserRefreshToken>
	{

	}
}
