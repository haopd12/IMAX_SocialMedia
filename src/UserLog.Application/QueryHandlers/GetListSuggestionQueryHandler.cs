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
	public class GetListSuggestionQueryHandler: IRequestHandler<GetListSuggestionQuery, PagedResultDto<SuggestionInformation>>
	{
		private readonly IPostRepository _postRepository;
		private readonly IGroupRepository _groupRepository;
		private readonly IGroupUserRepository _groupUserRepository;
		private readonly IFanpageRepository _fanpageRepository;
		private readonly IFanpageUserRepository _fanpageUserRepository;
		private readonly IAppSession _appSession;
		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IHomeMemberRepository _homeMemberRepository;
		private readonly ISuggestionRepository _suggestionRepository;
		private readonly IMapper _mapper;
		public GetListSuggestionQueryHandler(IAppSession appSession, IPostRepository PostRepository, IFriendshipRepository friendshipRepository,
			IHomeMemberRepository homeMemberRepository, IMapper mapper, IGroupRepository groupRepository, IGroupUserRepository groupUserRepository,
			IFanpageRepository fanpageRepository, IFanpageUserRepository fanpageUserRepository, ISuggestionRepository suggestionRepository)
		{
			_appSession = appSession;
			_postRepository = PostRepository;
			_friendshipRepository = friendshipRepository;
			_homeMemberRepository = homeMemberRepository;
			_mapper = mapper;
			_groupRepository = groupRepository;
			_groupUserRepository = groupUserRepository;
			_fanpageRepository = fanpageRepository;
			_fanpageUserRepository = fanpageUserRepository;
			_suggestionRepository = suggestionRepository;
		}
		public Task<PagedResultDto<SuggestionInformation>> Handle(GetListSuggestionQuery request, CancellationToken cancellationToken)
		{
			var listInfo = new List<SuggestionInformation>();
			var listFriend = _friendshipRepository.GetAll().Where(x => x.FriendUserId == request.UserId).ToList();
			var listUserSelection = _suggestionRepository.GetAll().Where(x => x.UserId == request.UserId).ToList();
			if (request.TypeOPost == TypeOPost.BelongedUser)
			{
				List<Friendship> friendOfFriends = new List<Friendship>();
				foreach (var friend in listFriend)
				{
					var list = _friendshipRepository.GetAll().Where(x => x.UserId == friend.FriendUserId).ToList();
					friendOfFriends.AddRange(list);
				}
				listInfo = _mapper.Map<List<SuggestionInformation>>(friendOfFriends);

			}
			if (request.TypeOPost == TypeOPost.BelongedGroup)
			{
				List<SuggestionInformation> groupOfFriends = new List<SuggestionInformation>();
				foreach (var friend in listFriend)
				{
					var list = _groupUserRepository.GetAll().Where(x => x.MemberId == friend.UserId);
					var groups = _groupRepository.GetAll();
					var joinData = from l in list
								   join gr in groups
								   on l.GroupId equals gr.Id
								   select new SuggestionInformation { ForeignId = gr.Id,
									   ImageUrl = gr.GroupProfilePictureUrl,
									   Name = gr.GroupName
								   };
					groupOfFriends.AddRange(joinData.ToList());
				}
				listInfo = groupOfFriends;
				
			}
			if (request.TypeOPost == TypeOPost.BelongedFanpage)
			{
				List<SuggestionInformation> fanpageOfFriends = new List<SuggestionInformation>();
				foreach (var friend in listFriend)
				{
					var list = _fanpageUserRepository.GetAll().Where(x => x.CensorId == friend.UserId);
					var groups = _fanpageRepository.GetAll();
					var joinData = from l in list
								   join gr in groups
								   on l.FanpageId equals gr.Id
								   select new SuggestionInformation
								   {
									   ForeignId = gr.Id,
									   ImageUrl = gr.FanpageProfilePictureUrl,
									   Name = gr.FanpageName
								   };
					fanpageOfFriends.AddRange(joinData.ToList());
				}
				listInfo = fanpageOfFriends;
			}
			var listInfo1 = new List<SuggestionInformation>();
			foreach (var ele in listInfo)
			{
				var qe = _suggestionRepository.GetAll()
					.Where(x => x.UserId == request.UserId)
					.Where(x => x.ForeignId == ele.ForeignId)
					.Where(x => x.TypeOSuggestion == request.TypeOPost)
					.ToList();
				if (qe.Count() == 0)
					listInfo1.Add(ele);
			}

			var list1 = listInfo1.Skip(request.SkipCount)
						.Take(request.MaxResultCount)
						.ToList();
			var totalCount = listInfo.Count();
			var result = new PagedResultDto<SuggestionInformation>()
			{
				TotalCount = totalCount,
				Items = list1
			};


			return Task.FromResult(result);
		}
	}
}
