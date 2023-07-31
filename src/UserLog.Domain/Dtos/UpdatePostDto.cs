using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLog.Domain.Dtos
{
	public class UpdatePostDto
	{
		public long Id { get; set; }
		public List<string>? ImageUrls { get; set; }
		public string? ContentPost { get; set; }
		public List<long>? TagFriendIds { get; set; }
		public int? State { get; set; }
		public int? Type { get; set; }
		public long? FeedbackId { get; set; }
	}
}
