using App.Shared.AppSession;
using App.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.Entities;
using UserLog.Domain.IQueries;
using UserLog.Domain.Repositories;

namespace UserLog.Application.QueryHandlers
{
	public class GetListFriendshipQueryHandler: IRequestHandler<GetListFriendshipQuery, PagedResultDto<Friendship>>
	{

		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IAppSession _appSession;

		public GetListFriendshipQueryHandler(IAppSession appSession, IFriendshipRepository friendshipRepository)
		{

			_appSession = appSession;
			_friendshipRepository = friendshipRepository;
		}
		public Task<PagedResultDto<Friendship>> Handle(GetListFriendshipQuery request, CancellationToken cancellationToken)
		{
			var q = _friendshipRepository.GetAll();
			var list = q.ToList();
			var totalCount = list.Count();
			var result = new PagedResultDto<Friendship>()
			{
				TotalCount = totalCount,
				Items = list
			};
			return Task.FromResult(result);
		}
	}
}
