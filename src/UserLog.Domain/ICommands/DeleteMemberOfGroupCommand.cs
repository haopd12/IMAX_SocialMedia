using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLog.Domain.ICommands
{
	public class DeleteMemberOfGroupCommand: IRequest<bool>
	{
		public long Id { get; set; }
	}
}
