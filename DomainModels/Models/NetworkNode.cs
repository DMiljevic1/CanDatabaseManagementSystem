using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanDatabaseManagementSystem.Domain.Models
{
	public class NetworkNode
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int DbcFileId { get; set; }
        public virtual DbcFile? DbcFile { get; set; }
    }
}
