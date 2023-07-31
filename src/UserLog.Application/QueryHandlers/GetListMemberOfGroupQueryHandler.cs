using Abp.Collections.Extensions;
using App.Shared.AppSession;
using App.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.IQueries;
using UserLog.Domain.Repositories;

namespace UserLog.Application.QueryHandlers
{
	public class GetListMemberOfGroupQueryHandler: IRequestHandler<GetListMemberOfGroupQuery, PagedResultDto<long>>
	{

		private readonly IGroupRepository _groupRepository;
		private readonly IGroupUserRepository _groupUserRepository;
		private readonly IAppSession _appSession;

		public GetListMemberOfGroupQueryHandler(IAppSession appSession, IGroupRepository groupRepository, IGroupUserRepository groupUserRepository)
		{

			_appSession = appSession;
			_groupRepository = groupRepository;
			_groupUserRepository = groupUserRepository;
		}
		public Task<PagedResultDto<long>> Handle(GetListMemberOfGroupQuery request, CancellationToken cancellationToken)
		{
			var groupUsers = _groupUserRepository.GetAll()
								.Where(x => x.GroupId == request.GroupId)
								.WhereIf(request.Permission.HasValue, x => x.Permission == request.Permission)
								.ToList();
			List<long> list = new List<long>();
			if (groupUsers == null)
			{
				return null;
			}
			foreach (var fu in groupUsers)
			{
				list.Add(fu.MemberId);
			}
			var list1 = list.Skip(request.SkipCount)
				.Take(request.MaxResultCount)
				.ToList();
			var totalCount = list.Count();
			var result = new PagedResultDto<long>()
			{
				TotalCount = totalCount,
				Items = list1
			};
			return Task.FromResult(result);
		}
	}
}
