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
	public enum permission
	{
		Admin = 0,
		Censor = 1,
		Follower = 2,
		Member = 3
	}
	[Table("FanpageUser")]
	public class FanpageUser: FullAuditedEntity<long>, IMayHaveTenant
	{
		public int? TenantId { get; set; }
		public long FanpageId { get; set; }
		public long CensorId { get; set; }
		public permission? Permission { get; set; }

	}
}
