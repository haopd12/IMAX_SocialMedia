using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserLog.Domain.Entities
{
	public enum FriendshipState
	{
		Accepted = 1,
		Blocked = 2,
		Requesting = 3,
		IsChat = 4,
		IsDeleted = 5,
	}

	[Table("AppFriendships")]
	public class Friendship : Entity<long>, IHasCreationTime, IMayHaveTenant
	{
		public long UserId { get; set; }

		public int? TenantId { get; set; }

		public long FriendUserId { get; set; }

		public int? FriendTenantId { get; set; }

		[Required]
		[MaxLength(256)]
		public string? FriendUserName { get; set; }

		public string? FriendTenancyName { get; set; }

		public string? FriendProfilePictureId { get; set; }
		public bool? IsSender { get; set; }
		public bool? IsOrganizationUnit { get; set; }

		public FriendshipState State { get; set; }

		public DateTime CreationTime { get; set; }

	}
}
