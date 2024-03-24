using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
	public class Message
	{
        public int Id { get; set; }
        public long CanMessageId { get; set; }
        public string Name { get; set; }
        public int DbcFileId { get; set; }
        public virtual DbcFile? DbcFile { get; set; }
		public ICollection<Signal> Signals { get; private set; } = new List<Signal>();
	}
}
