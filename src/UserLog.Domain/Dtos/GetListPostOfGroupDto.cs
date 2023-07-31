﻿using App.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLog.Domain.Dtos
{
	public class GetListPostOfGroupDto: PagedInputDto
	{
		public long GroupId { get; set; }
		public long? UserId { get; set; }
	}
}
