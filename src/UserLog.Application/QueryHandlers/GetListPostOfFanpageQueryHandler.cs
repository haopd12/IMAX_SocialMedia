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
	public class GetListPostOfFanpageQueryHandler: IRequestHandler<GetListPostOfFanpageQuery, PagedResultDto<Post>>
	{

		private readonly IPostRepository _postRepository;
		private readonly IFanpageRepository _fanpageRepository;
		private readonly IFanpageUserRepository _fanpageUserRepository;
		private readonly IAppSession _appSession;
		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IHomeMemberRepository _homeMemberRepository;
		private readonly IMapper _mapper;
		public GetListPostOfFanpageQueryHandler(IAppSession appSession, IPostRepository PostRepository, IFriendshipRepository friendshipRepository,
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
		public Task<PagedResultDto<Post>> Handle(GetListPostOfFanpageQuery request, CancellationToken cancellationToken)
		{
			var posts = _postRepository.GetAll()
							.Where(x => x.ForeignId == request.FanpageId)
							.Where(x => x.TypeOPost == TypeOPost.BelongedFanpage)
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
