using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.Entities;

namespace UserLog.Domain.Dtos
{
	public class UpdateLikePostDto
	{
		public long Id { get; set; }
		public LikeState? StateLike { get; set; }
	}
}
