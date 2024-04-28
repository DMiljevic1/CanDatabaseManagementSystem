using CanDatabaseManagementSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDatabaseManagementSystem.Domain.Repositories
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetMessages(int dbcFileId, CancellationToken cancellationToken);
    }
}
