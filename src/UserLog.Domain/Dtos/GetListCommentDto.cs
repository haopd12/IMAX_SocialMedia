using App.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLog.Domain.Dtos
{
	public class GetListCommentDto: PagedInputDto
	{
		public long PostId { get; set; }
		public long ParentCommentId { get; set; }
	}
}
