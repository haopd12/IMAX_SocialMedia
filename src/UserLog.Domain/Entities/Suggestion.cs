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
	[Table("Suggestion")]
	public class Suggestion: FullAuditedEntity<long>, IMayHaveTenant
	{
		public int? TenantId { get; set; }
		public long UserId { get; set; }
		public long ForeignId { get; set; }
		public TypeOPost TypeOSuggestion { get; set; }
		public bool IsChosen { get; set; }

	}
}
