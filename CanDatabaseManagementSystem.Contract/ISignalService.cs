using CanDatabaseManagementSystem.Common.DtoModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDatabaseManagementSystem.Contract
{
    public interface ISignalService
    {
        Task<List<SignalDto>> GetSignals(int messageId, CancellationToken cancellationToken);
    }
}
