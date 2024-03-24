using CanDatabaseManagementSystem.Common.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDatabaseManagementSystem.Contract
{
    public interface IMessageService
    {
        Task<List<MessageDto>> GetMessages(int dbcFileId, CancellationToken cancellationToken);
    }
}
