﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.Entities;

namespace UserLog.Domain.Dtos
{
	public class UpdateCensorOfFanpageDto
	{
		public long Id { get; set; }
		public long CensorId { get; set; }
		public permission Permission { get; set; }
	}
}
