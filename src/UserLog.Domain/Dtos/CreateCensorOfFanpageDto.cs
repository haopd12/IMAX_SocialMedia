using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.Entities;

namespace UserLog.Domain.Dtos
{
	public class CreateCensorOfFanpageDto
	{
		public long FanpageId { get; set; }
		public long CensorId { get; set; }
		public permission Permission { get; set; }
	}
}
