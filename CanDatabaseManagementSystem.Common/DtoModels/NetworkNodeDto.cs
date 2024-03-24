using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDatabaseManagementSystem.Common.DtoModels
{
	public class NetworkNodeDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int DbcFileId { get; set; }
		public virtual DbcFileDto? DbcFile { get; set; }
	}
}
