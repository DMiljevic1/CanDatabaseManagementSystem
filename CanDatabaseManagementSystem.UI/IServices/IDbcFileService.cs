﻿using CanDatabaseManagementSystem.Common.DtoModels;

namespace CanDatabaseManagementSystem.UI.IServices
{
	public interface IDbcFileService
	{
		Task<List<DbcFileDto>> GetDbcFiles();
	}
}