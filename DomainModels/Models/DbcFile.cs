using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDatabaseManagementSystem.Domain.Models
{
	public class DbcFile
	{
        public int Id { get; set; }
        public string Name { get; set; }
		public ICollection<NetworkNode> NetworkNodes { get; private set; } = new List<NetworkNode>();

		public ICollection<Message> Messages { get; private set; } = new List<Message>();
	}
}
