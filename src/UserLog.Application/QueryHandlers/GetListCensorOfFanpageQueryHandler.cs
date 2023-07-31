using Abp.Collections.Extensions;
using App.Shared.AppSession;
using App.Shared.Dtos;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.Dtos;
using UserLog.Domain.IQueries;
using UserLog.Domain.Repositories;

namespace UserLog.Application.QueryHandlers
{
	public class GetListCensorOfFanpageQueryHandler: IRequestHandler<GetListCensorOfFanpageQuery, PagedResultDto<long>>
	{

		private readonly IPostRepository _postRepository;
		private readonly IFanpageRepository _fanpageRepository;
		private readonly IFanpageUserRepository _fanpageUserRepository;
		private readonly IAppSession _appSession;
		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IHomeMemberRepository _homeMemberRepository;
		private readonly IMapper _mapper;
		public GetListCensorOfFanpageQueryHandler(IAppSession appSession, IPostRepository PostRepository, IFriendshipRepository friendshipRepository,
			IHomeMemberRepository homeMemberRepository, IMapper mapper, IFanpageRepository fanpageRepository, IFanpageUserRepository fanpageUserRepository)
		{
			_appSession = appSession;
			_postRepository = PostRepository;
			_friendshipRepository = friendshipRepository;
			_homeMemberRepository = homeMemberRepository;
			_mapper = mapper;
			_fanpageRepository = fanpageRepository;
			_fanpageUserRepository = fanpageUserRepository;
		}
		public Task<PagedResultDto<long>> Handle(GetListCensorOfFanpageQuery request, CancellationToken cancellationToken)
		{
			var fanpageUsers = _fanpageUserRepository.GetAll()
								.Where(x => x.FanpageId == request.FanpageId)
								.WhereIf(request.Permission.HasValue, x => x.Permission == request.Permission)
								.ToList();
			List<long> userIds = new List<long>();
			foreach(var user in fanpageUsers)
			{
				userIds.Add(user.CensorId);
			}
			
			var list1 = userIds.Skip(request.SkipCount)
				.Take(request.MaxResultCount)
				.ToList();

			/*var list = q.ToList();*/
			var totalCount = userIds.Count();
			var result = new PagedResultDto<long>()
			{
				TotalCount = totalCount,
				Items = list1
			};
			return Task.FromResult(result);
		}
	}
}
