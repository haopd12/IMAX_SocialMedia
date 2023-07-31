using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLog.Domain.Dtos
{
	public class UpdatePostCommentDto
	{
		public long Id { get; set; }
		public string Comment { get; set; }
	}
}
