using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLog.Domain.Entities
{
	public enum FanpageState
	{
		PENDING = 1,
		ACTIVATED = 2,
		INACTIVATED = 3,
		HIDDEN = 4,
		BLOCKED = 5,
	}
	[Table("Fanpage")]
	public class Fanpage: FullAuditedEntity<long>, IMayHaveTenant
	{
		public int? TenantId { get; set; }
		public string FanpageName { get; set; }
		public string? FanpageProfilePictureUrl { get; set; }
		public FanpageState? State { get; set; }

	}
}
