using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.Entities;

namespace UserLog.Domain.Dtos
{
	public class JoinFanpageUserDto
	{
		public string FanpageName { get; set; }
		public string? FanpageProfilePictureUrl { get; set; }
		public FanpageState? State { get; set; }
		public permission? Permission { get; set; }
	}
}
