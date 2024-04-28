using CanDatabaseManagementSystem.DAL.DatabaseContext;
using CanDatabaseManagementSystem.Domain.Models;
using CanDatabaseManagementSystem.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDatabaseManagementSystem.DAL.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly CanDatabaseContext _canDatabaseContext;
        public MessageRepository(CanDatabaseContext canDatabaseContext)
        {
            _canDatabaseContext = canDatabaseContext;
        }
        public async Task<List<Message>> GetMessages(int dbcFileId, CancellationToken cancellationToken)
        {
            return await _canDatabaseContext.Messages.Where(m => m.DbcFileId == dbcFileId).ToListAsync(cancellationToken);
        }
    }
}
