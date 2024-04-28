using CanDatabaseManagementSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDatabaseManagementSystem.Domain.Repositories
{
	public interface IDbcFileRepository
	{
		Task<List<DbcFile>> GetDbcFiles(CancellationToken cancellationToken);
		Task AddDbcFile(DbcFile dbcFile, CancellationToken cancellationToken);
		Task DeleteDbcFile(int dbcFileId, CancellationToken cancellationToken);
	}
}
