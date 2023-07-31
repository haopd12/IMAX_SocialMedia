﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLog.Domain.ICommands
{
	public class DeleteFanpageByAdminCommand: IRequest<bool>
	{
		public long Id { get; set; }
	}
}