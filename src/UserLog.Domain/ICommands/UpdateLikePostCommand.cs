using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.Dtos;

namespace UserLog.Domain.ICommands
{
	public class UpdateLikePostCommand: UpdateLikePostDto, IRequest<bool>
	{
	}
}
