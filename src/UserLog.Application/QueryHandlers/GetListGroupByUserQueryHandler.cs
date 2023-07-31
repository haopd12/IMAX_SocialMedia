using Abp.Collections.Extensions;
using App.Shared.AppSession;
using App.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.Dtos;
using UserLog.Domain.Entities;
using UserLog.Domain.IQueries;
using UserLog.Domain.Repositories;
using UserLog.Infrastructure.Repositories;

namespace UserLog.Application.QueryHandlers
{
	public class GetListGroupByUserQueryHandler: IRequestHandler<GetListGroupByUserQuery, PagedResultDto<Group>>
	{

		private readonly IGroupRepository _groupRepository;
		private readonly IGroupUserRepository _groupUserRepository;
		private readonly IAppSession _appSession;

		public GetListGroupByUserQueryHandler(IAppSession appSession, IGroupRepository groupRepository, IGroupUserRepository groupUserRepository)
		{

			_appSession = appSession;
			_groupRepository = groupRepository;
			_groupUserRepository = groupUserRepository;
		}
		public Task<PagedResultDto<Group>> Handle(GetListGroupByUserQuery request, CancellationToken cancellationToken)
		{
			var groupUsers = _groupUserRepository.GetAll()
								.Where(x => x.MemberId == request.UserId)
								.WhereIf(request.Permission.HasValue, x => x.Permission == request.Permission)
								.ToList();
			List<Group> list = new List<Group>();
			if (groupUsers == null)
			{
				return null;
			}
			foreach (var fu in groupUsers)
			{
				var f = _groupRepository.FirstOrDefault(fu.GroupId);
				list.Add(f);
			}
			var list1 = list.Skip(request.SkipCount)
				.Take(request.MaxResultCount)
				.OrderByDescending(x => x.LastModificationTime)
				.ToList();
			var totalCount = list.Count();
			var result = new PagedResultDto<Group>()
			{
				TotalCount = totalCount,
				Items = list1
			};
			return Task.FromResult(result);
		}
	}
}
