using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLog.Domain.Dtos
{
	public class CreatePostCommentDto
	{
		public string Comment { get; set; }
		public long? ParentCommentId { get; set; }
		public long? PostId { get; set; }
	}
}
