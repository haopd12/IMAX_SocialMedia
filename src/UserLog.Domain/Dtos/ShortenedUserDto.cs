using App.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLog.Domain.Dtos
{
	public class ShortenedUserDto: PagedInputDto
	{
		public long UserId { get; set; }
		public string UserName { get; set; }
		public string UserProfilePictureUrl { get; set; }
		
	}
}
