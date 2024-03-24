using AutoMapper;
using CanDatabaseManagementSystem.Common.DtoModels;
using CanDatabaseManagementSystem.Contract;
using DomainModels.Models;
using DomainModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDatabaseManagementSystem.Service
{
	public class DbcFileService : IDbcFileService
	{
		private readonly IDbcFileRepository _dbcFileRepository;
		private readonly IMapper _mapper;
		private readonly IDbcFileParserService _dbcFileParserService;
		public DbcFileService(IDbcFileRepository dbcFileRepository, IMapper mapper, IDbcFileParserService dbcFileParserService)
		{
			_dbcFileRepository = dbcFileRepository;
			_mapper = mapper;
			_dbcFileParserService = dbcFileParserService;
		}

		public async Task<List<DbcFileDto>> GetDbcFiles(CancellationToken cancellationToken)
		{
			var dbcFiles = await _dbcFileRepository.GetDbcFiles(cancellationToken);
			var dbcFileDtos = new List<DbcFileDto>();
			foreach (var dbcFile in dbcFiles)
			{
				dbcFileDtos.Add(_mapper.Map<DbcFileDto>(dbcFile));
			}
			
			return dbcFileDtos;
		}

        public async Task UploadDbcFile(DbcFileData dbcFileData, CancellationToken cancellationToken)
        {
			var dbcFile = new DbcFile();
			dbcFile = await _dbcFileParserService.Parse(dbcFileData);
            await _dbcFileRepository.AddDbcFile(dbcFile, cancellationToken);
        }
    }
}
