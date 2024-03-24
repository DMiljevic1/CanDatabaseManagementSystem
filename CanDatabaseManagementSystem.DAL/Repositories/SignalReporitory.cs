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
    public class SignalReporitory : ISignalRepository
    {
        private readonly CanDatabaseContext _canDatabaseContext;
        public SignalReporitory(CanDatabaseContext canDatabaseContext)
        {
            _canDatabaseContext = canDatabaseContext;
        }
        public async Task<List<Signal>> GetSignals(int messageId, CancellationToken cancellationToken)
        {
            return await _canDatabaseContext.Signals.ToListAsync(cancellationToken);
        }
    }
}
