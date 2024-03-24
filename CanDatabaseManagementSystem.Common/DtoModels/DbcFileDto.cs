using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDatabaseManagementSystem.Common.DtoModels
{
	public class DbcFileDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<NetworkNodeDto> NetworkNodes { get; private set; } = new List<NetworkNodeDto>();

		public ICollection<MessageDto> Messages { get; private set; } = new List<MessageDto>();
	}
}
