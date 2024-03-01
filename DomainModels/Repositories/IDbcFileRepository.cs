﻿using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Repositories
{
	public interface IDbcFileRepository
	{
		Task<List<DbcFile>> GetDbcFiles(CancellationToken cancellationToken);
	}
}