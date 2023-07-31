using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.Entities;

namespace UserLog.Domain.Dtos
{
	public class CreatePostDto
	{
		public long ForeignId { get; set; }
		public TypeOPost TypeOPost { get; set; }
		public List<string>? ImageUrls { get; set; }
		public string? ContentPost { get; set; }
		public List<long>? TagFriendIds { get; set; }
		public int? State { get; set; }
		public int? Type { get; set; }
		public long? FeedbackId { get; set; }
		public bool IsShared { get; set; } = false;
		public long? SharedPostId { get; set; }
	}
}
