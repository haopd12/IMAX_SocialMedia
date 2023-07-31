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
using UserLog.Domain.Entities;
using UserLog.Domain.IQueries;
using UserLog.Domain.Repositories;

namespace UserLog.Application.QueryHandlers
{
	public class GetListFanpageByUserQueryHandler: IRequestHandler<GetListFanpageByUserQuery, PagedResultDto<JoinFanpageUserDto>>
	{

		private readonly IPostRepository _postRepository;
		private readonly IFanpageRepository _fanpageRepository;
		private readonly IFanpageUserRepository _fanpageUserRepository;
		private readonly IAppSession _appSession;
		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IHomeMemberRepository _homeMemberRepository;
		private readonly IMapper _mapper;
		public GetListFanpageByUserQueryHandler(IAppSession appSession, IPostRepository PostRepository, IFriendshipRepository friendshipRepository,
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
		public Task<PagedResultDto<JoinFanpageUserDto>> Handle(GetListFanpageByUserQuery request, CancellationToken cancellationToken)
		{
			var fanpageUsers = _fanpageUserRepository.GetAll()
								.Where(x => x.CensorId == request.UserId)
								.WhereIf(request.Permission.HasValue, x => x.Permission == request.Permission)
								.ToList();
			List<JoinFanpageUserDto> list = new List<JoinFanpageUserDto> ();
			if (fanpageUsers == null) {
				return null;
			}
			foreach (var fu in fanpageUsers)
			{
				var f = _fanpageRepository.FirstOrDefault(fu.FanpageId);
				var jf = _mapper.Map<JoinFanpageUserDto>(f);
				jf.Permission = fu.Permission;
				list.Add(jf);
			}
			var list1 = list.Skip(request.SkipCount)
				.Take(request.MaxResultCount)
				.ToList();

			/*var list = q.ToList();*/
			var totalCount = list.Count();
			var result = new PagedResultDto<JoinFanpageUserDto>()
			{
				TotalCount = totalCount,
				Items = list1
			};
			return Task.FromResult(result);
		}
	}
}
