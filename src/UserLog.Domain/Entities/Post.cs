using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLog.Domain.Entities
{
	public enum TypeOPost
	{
		BelongedUser = 1,
		BelongedFanpage = 2,
		BelongedGroup = 3
	}
	[Table("Post")]
	public class Post : FullAuditedEntity<long>, IMayHaveTenant
	{
		public int? TenantId { get; set; }
		public long? ForeignId { get; set; }
		public TypeOPost TypeOPost { get; set; }
		public string? ContentPost { get; set; }
		public int? State { get; set; }
		public int? Type { get; set; }
		public long? FeedbackId { get; set; }
		public List<long>? TagFriendIds { get; set; }
		public List<string>? ImageUrls { get; set; }
		public bool IsShared { get; set; }
		public long? SharedPostId { get; set; }
	}
}
