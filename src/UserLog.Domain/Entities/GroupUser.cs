using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserLog.Domain.Entities
{
	public enum GroupState
	{
		PENDING = 1,
		ACTIVATED = 2,
		INACTIVATED = 3,
		HIDDEN = 4,
		BLOCKED = 5,
	}
	[Table("GroupUser")]
	public class GroupUser: FullAuditedEntity<long>, IMayHaveTenant
	{
		public int? TenantId { get; set; }
		public long GroupId { get; set; }
		public long MemberId { get; set; }
		public permission? Permission { get; set; }
		public GroupState State { get; set; }
	}
}
