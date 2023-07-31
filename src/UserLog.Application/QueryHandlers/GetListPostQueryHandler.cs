using Abp.Collections.Extensions;
using App.Shared.AppSession;
using App.Shared.Dtos;
using App.Shared.Uow;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using MongoDB.Driver.Linq;
using UserLog.Domain.Entities;
using UserLog.Domain.IQueries;
using UserLog.Domain.Repositories;
using System.Linq;
using System.Collections.Generic;

namespace UserLog.Application.QueryHandlers
{
	public class GetListPostQueryHandler: IRequestHandler<GetListPostQuery, PagedResultDto<Post>>
	{
		
		private readonly IPostRepository _postRepository;
		private readonly IFanpageRepository _fanpageRepository;
		private readonly IFanpageUserRepository _fanpageUserRepository;
		private readonly IGroupRepository _groupRepository;
		private readonly IGroupUserRepository _groupUserRepository;
		private readonly IAppSession _appSession;
		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IHomeMemberRepository _homeMemberRepository;
		private readonly IMapper _mapper;
		public GetListPostQueryHandler(IAppSession appSession, IPostRepository PostRepository, IFriendshipRepository friendshipRepository,
			IHomeMemberRepository homeMemberRepository, IMapper mapper, IFanpageRepository fanpageRepository, 
			IFanpageUserRepository fanpageUserRepository, IGroupRepository groupRepository, IGroupUserRepository groupUserRepository)
		{
			_appSession = appSession;
			_postRepository = PostRepository;
			_friendshipRepository = friendshipRepository;
			_homeMemberRepository = homeMemberRepository;
			_mapper = mapper;
			_fanpageRepository = fanpageRepository;
			_fanpageUserRepository = fanpageUserRepository;
			_groupRepository = groupRepository;
			_groupUserRepository = groupUserRepository;
		}
		public Task<PagedResultDto<Post>> Handle(GetListPostQuery request, CancellationToken cancellationToken)
		{
			var f = _friendshipRepository.GetAll()
				.Where(x => x.FriendUserId == request.UserId)
				.ToList();
			var HMCode = _homeMemberRepository.FirstOrDefault(x => x.UserId == request.UserId);
			List<Post> posts = new List<Post>();
			foreach (var item in f)
			{
				var q = _postRepository.GetAll()
				.Where(x => x.CreatorUserId == item.UserId)
				.ToList();
				posts.AddRange(q);
			}
			if (HMCode != null)
			{
				var ha = _homeMemberRepository.GetAll()
					.Where(x => x.SmartHomeCode == HMCode.SmartHomeCode)
					.ToList();
				if (ha != null)
				{
					foreach (var item in ha)
					{
						var q = _postRepository.GetAll()
							.Where(x => x.CreatorUserId == item.UserId)
							.ToList();
						posts.AddRange(q);
					}
				}
			}

			var fanpageFollower = _fanpageUserRepository.GetAll()
				.Where(x => x.CensorId == request.UserId).ToList();
			foreach (var item in fanpageFollower)
			{
				var post = _postRepository.GetAll()
					.Where(x => x.ForeignId == item.FanpageId)
					.Where(x => x.TypeOPost == TypeOPost.BelongedFanpage) .ToList();
				posts.AddRange(post);
			}

			var groupMember = _groupUserRepository.GetAll()
				.Where(x => x.MemberId == request.UserId)
				.Where(x => x.State != GroupState.BLOCKED)
				.ToList();
			foreach (var item in groupMember)
			{
				var post = _postRepository.GetAll()
					.Where(x => x.ForeignId == item.GroupId)
					.Where(x => x.TypeOPost == TypeOPost.BelongedGroup).ToList();
				posts.AddRange(post);
			}
			var list = posts.Skip(request.SkipCount)
				.Take(request.MaxResultCount)
				.OrderByDescending(x => x.LastModificationTime)
				.ToList();
			var totalCount = posts.Count();
			var result = new PagedResultDto<Post>()
			{
				TotalCount = totalCount,
				Items = list
			};
			return Task.FromResult(result);
		}
	}
}
