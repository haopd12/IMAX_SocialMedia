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
using UserLog.Domain.Entities;
using UserLog.Domain.IQueries;
using UserLog.Domain.Repositories;

namespace UserLog.Application.QueryHandlers
{
	public class GetListPostOfGroupQueryHandler: IRequestHandler<GetListPostOfGroupQuery, PagedResultDto<Post>>
	{

		private readonly IPostRepository _postRepository;
		private readonly IGroupRepository _groupRepository;
		private readonly IGroupUserRepository _groupUserRepository;
		private readonly IAppSession _appSession;
		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IHomeMemberRepository _homeMemberRepository;
		private readonly IMapper _mapper;
		public GetListPostOfGroupQueryHandler(IAppSession appSession, IPostRepository PostRepository, IFriendshipRepository friendshipRepository,
			IHomeMemberRepository homeMemberRepository, IMapper mapper, IGroupRepository groupRepository, IGroupUserRepository groupUserRepository)
		{
			_appSession = appSession;
			_postRepository = PostRepository;
			_friendshipRepository = friendshipRepository;
			_homeMemberRepository = homeMemberRepository;
			_mapper = mapper;
			_groupRepository = groupRepository;
			_groupUserRepository = groupUserRepository;
		}
		public Task<PagedResultDto<Post>> Handle(GetListPostOfGroupQuery request, CancellationToken cancellationToken)
		{
			var posts = _postRepository.GetAll()
							.Where(x => x.ForeignId == request.GroupId)
							.Where(x => x.TypeOPost == TypeOPost.BelongedGroup)
							.WhereIf(request.UserId.HasValue, x => x.CreatorUserId == request.UserId)
							.ToList();

			/*var list = q.ToList();*/
			var totalCount = posts.Count();
			var result = new PagedResultDto<Post>()
			{
				TotalCount = totalCount,
				Items = posts
			};
			return Task.FromResult(result);
		}
	}
}
