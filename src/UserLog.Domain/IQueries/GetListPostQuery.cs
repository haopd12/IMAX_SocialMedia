using App.Shared.Dtos;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.Dtos;
using UserLog.Domain.Entities;

namespace UserLog.Domain.IQueries
{
	public class GetListPostQuery: GetListPost, IRequest<PagedResultDto<Post>> 
	{

	}
}
