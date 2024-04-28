using AutoMapper;
using CanDatabaseManagementSystem.Common.DtoModels;
using CanDatabaseManagementSystem.Contract;
using CanDatabaseManagementSystem.Domain.Models;
using CanDatabaseManagementSystem.Domain.Repositories;
using Microsoft.Extensions.Logging;
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
		private readonly ILogger<DbcFileService> _logger;
		public DbcFileService(IDbcFileRepository dbcFileRepository, IMapper mapper, IDbcFileParserService dbcFileParserService, ILogger<DbcFileService> logger)
		{
			_dbcFileRepository = dbcFileRepository;
			_mapper = mapper;
			_dbcFileParserService = dbcFileParserService;
			_logger = logger;
		}

        public async Task DeleteDbcFile(int dbcFileId, CancellationToken cancellationToken)
        {
			try
			{
				await _dbcFileRepository.DeleteDbcFile(dbcFileId, cancellationToken);
				_logger.LogDebug("DeleteDbcFile successfull. DbcFileId: " + dbcFileId);
			}
			catch (Exception e)
			{
				_logger.LogError("Error has occured: " + e.Message);
				throw;
			}
        }

        public async Task<List<DbcFileDto>> GetDbcFiles(CancellationToken cancellationToken)
		{
			try
			{
                var dbcFiles = await _dbcFileRepository.GetDbcFiles(cancellationToken);
				_logger.LogDebug("GetDbcFiles successfull. Response: " + dbcFiles);
                var dbcFileDtos = new List<DbcFileDto>();
                foreach (var dbcFile in dbcFiles)
                {
                    dbcFileDtos.Add(_mapper.Map<DbcFileDto>(dbcFile));
                }
				_logger.LogDebug("DbcFiles mapped into dbcFileDtos successfull. Response: " + dbcFileDtos);

                return dbcFileDtos;
            }
			catch (Exception e)
			{
                _logger.LogError("Error has occured: " + e.Message);
                throw;
            }
		}

        public async Task UploadDbcFile(DbcFileData dbcFileData, CancellationToken cancellationToken)
        {
			try
			{
                var dbcFile = new DbcFile();
                dbcFile = await _dbcFileParserService.Parse(dbcFileData);
				_logger.LogDebug($"DbcFile parsed successfully. DbcFileForParsing: {dbcFileData}, ParsedDbcFile: {dbcFile}");
                await _dbcFileRepository.AddDbcFile(dbcFile, cancellationToken);
				_logger.LogDebug("AddDbcFile successfull. DbcFile: " + dbcFile);
            }
			catch (Exception e)
			{
                _logger.LogError("Error has occured: " + e.Message);
                throw;
			}
        }
    }
}
