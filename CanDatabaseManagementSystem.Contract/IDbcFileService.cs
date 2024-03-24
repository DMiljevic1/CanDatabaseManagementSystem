using CanDatabaseManagementSystem.Common.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDatabaseManagementSystem.Contract
{
	public interface IDbcFileService
	{
		Task<List<DbcFileDto>> GetDbcFiles(CancellationToken cancellationToken);
		Task UploadDbcFile(DbcFileData dbcFileData, CancellationToken cancellation);

    }
}
