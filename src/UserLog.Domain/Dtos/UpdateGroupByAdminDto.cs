using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.Entities;

namespace UserLog.Domain.Dtos
{
	public class UpdateGroupByAdminDto
	{
		public long Id { get; set; }
		public string? GroupName { get; set; }
		public string? GroupProfilePictureUrl { get; set; }
		public bool IsPublic { get; set; }
		public GroupState? State { get; set; }
	}
}
