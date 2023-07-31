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
	[Table("Group")]
	public class Group: FullAuditedEntity<long>, IMayHaveTenant
	{
		public int? TenantId { get; set; }
		public string GroupName { get; set; }
		public string? GroupProfilePictureUrl { get; set; }
		public bool IsPublic { get; set; }
		public GroupState? State { get; set; }
	}
}
