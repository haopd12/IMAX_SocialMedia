﻿using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLog.Domain.Entities
{
	[Table("HomeMembers")]
	public class HomeMember : Entity<long>, IMayHaveTenant
	{
		[StringLength(2000)]
		public string SmartHomeCode { get; set; }
		public long? UserId { get; set; }
		public bool IsVoter { get; set; }
		public bool IsAdmin { get; set; }
		public int? TenantId { get; set; }
		[StringLength(1000)]
		public string? ApartmentCode { get; set; }
		public bool IsActive { get; set; }
	}
}
