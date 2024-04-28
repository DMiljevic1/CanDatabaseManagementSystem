using CanDatabaseManagementSystem.Common.DtoModels;
using CanDatabaseManagementSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDatabaseManagementSystem.Contract
{
    public interface IDbcFileParserService
    {
        Task<DbcFile> Parse(DbcFileData dbcFileData);
    }
}
