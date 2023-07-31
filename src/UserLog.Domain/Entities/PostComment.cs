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
	[Table("PostComment")]
	public class PostComment : FullAuditedEntity<long>, IMayHaveTenant
	{
		public int? TenantId { get; set; }
		public string Comment { get; set; }
		public long? ParentCommentId { get; set; }
		public long? PostId { get; set; }
	}
}
