using CanDatabaseManagementSystem.DAL.DatabaseContext;
using DomainModels.Models;
using DomainModels.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDatabaseManagementSystem.DAL.Repositories
{
	public class DbcFileRepository : IDbcFileRepository
	{
		private readonly CanDatabaseContext _canDatabaseContext;
		public DbcFileRepository(CanDatabaseContext canDatabaseContext)
		{
			_canDatabaseContext = canDatabaseContext;
		}

        public async Task AddDbcFile(DbcFile dbcFile, CancellationToken cancellationToken)
        {
			if(dbcFile != null)
			{
                await _canDatabaseContext.DbcFiles.AddAsync(dbcFile, cancellationToken);
                await _canDatabaseContext.SaveChangesAsync();
            }
        }

        public async Task DeleteDbcFile(int dbcFileId, CancellationToken cancellationToken)
        {
			var dbcFileForDelete = await GetDbcFile(dbcFileId);
            if(dbcFileForDelete != null)
			{
				_canDatabaseContext.DbcFiles.Remove(dbcFileForDelete);
                await _canDatabaseContext.SaveChangesAsync(cancellationToken);
            }
        }
		private async Task<DbcFile?> GetDbcFile(int dbcFileId)
		{
			var dbcFile = await _canDatabaseContext.DbcFiles.FirstOrDefaultAsync(dbc => dbc.Id == dbcFileId);
			return dbcFile;
		}

        public async Task<List<DbcFile>> GetDbcFiles(CancellationToken cancellationToken)
		{
			return await _canDatabaseContext.DbcFiles.ToListAsync(cancellationToken);
		}
	}
}
