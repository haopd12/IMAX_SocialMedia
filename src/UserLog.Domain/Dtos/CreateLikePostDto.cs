using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.Entities;

namespace UserLog.Domain.Dtos
{
	public class CreateLikePostDto
	{
		public LikeState? StateLike { get; set; }
		public long? CommentId { get; set; }
		public long? PostId { get; set; }
	}
}
