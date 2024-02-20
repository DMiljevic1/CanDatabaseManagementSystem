using DomainModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDatabaseManagementSystem.DAL.DatabaseContext
{
	public class CanDatabaseContext : DbContext
	{
		public CanDatabaseContext(DbContextOptions<CanDatabaseContext> options) : base(options) { }

		public DbSet<NetworkNode> NetworkNodes { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<Signal> Signals { get; set; }
		public DbSet<DbcFile> DbcFiles { get; set; }
	}
}
