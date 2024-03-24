using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDatabaseManagementSystem.Common.DtoModels
{
	public class SignalDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int StartBit { get; set; }
		public int Lenght { get; set; }
		public int MessageId { get; set; }
		public virtual MessageDto? Message { get; set; }
	}
}
