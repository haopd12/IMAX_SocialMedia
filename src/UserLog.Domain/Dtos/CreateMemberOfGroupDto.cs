using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.Entities;

namespace UserLog.Domain.Dtos
{
	public class CreateMemberOfGroupDto
	{
		public long GroupId { get; set; }
		public long MemberId { get; set; }
		public permission? Permission { get; set; }
		public GroupState? State { get; set; }
	}
}
