﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Models
{
	public class Signal
	{
        public int Id { get; set; }
		public string Name { get; set; }
        public int StartBit { get; set; }
        public int Lenght { get; set; }
    }
}
