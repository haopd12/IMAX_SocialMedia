using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.Entities;

namespace UserLog.Domain.Dtos
{
	public class UpdateMemberOfGroupDto
	{
		public long Id { get; set; }
		public permission? Permission { get; set; }
		public GroupState State { get; set; }
	}
}
