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
	public enum LikeState
	{
		Like = 1,
		Favorite = 2,
		ThuongThuong =3,
		Haha = 4,
		Wow = 5,
		Sad = 6,
		Angry = 7,
	}
	[Table("LikePost")]
	public class LikePost : FullAuditedEntity<long>, IMayHaveTenant
	{
		public int? TenantId { get; set; }
		public LikeState? StateLike { get; set; }
		public long? CommentId { get; set; }
		public long? PostId { get; set; }
	}
}
