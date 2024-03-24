﻿using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Repositories
{
    public interface ISignalRepository
    {
        Task<List<Signal>> GetSignals(int messageId, CancellationToken cancellationToken);
    }
}
