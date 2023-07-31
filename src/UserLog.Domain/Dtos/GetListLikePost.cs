using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.Entities;

namespace UserLog.Domain.Dtos
{
	public class GetListLikePost
	{
		public long PostId { get; set; }
		public long CommentId { get; set; }	
		public LikeState? StateLike { get; set; }
	}
}
