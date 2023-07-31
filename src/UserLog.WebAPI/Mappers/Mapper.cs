using AutoMapper;
using UserLog.Domain.Dtos;
using UserLog.Domain.Entities;
using UserLog.Domain.ICommands;
using UserLog.Domain.IQueries;

namespace UserLog.WebAPI.Mappers
{
	public class Mapper: Profile
	{
		public Mapper() {
			CreateMap<GetListPost, GetListPostQuery>().ReverseMap();
			CreateMap<GetListFriendship, GetListFriendshipQuery>().ReverseMap();
			CreateMap<GetListLikePost, GetListLikePostQuery>().ReverseMap();
			CreateMap<GetListCommentDto,GetListCommentQuery>().ReverseMap();

			CreateMap<CreatePostDto, CreatePostCommand>().ReverseMap();
			CreateMap<CreatePostCommand, Post>().ReverseMap();
			CreateMap<UpdatePostDto, UpdatePostCommand>().ReverseMap();
			CreateMap<UpdatePostCommand, Post>().ReverseMap();
			CreateMap<DeletePostDto, DeletePostCommand>().ReverseMap();

			CreateMap<CreatePostCommentDto, CreatePostCommentCommand>().ReverseMap();
			CreateMap<CreatePostCommentCommand, PostComment>().ReverseMap();
			CreateMap<UpdatePostCommentDto, UpdatePostCommentCommand>().ReverseMap();
			CreateMap<UpdatePostCommentCommand, PostComment>().ReverseMap();
			CreateMap<DeletePostCommentDto, DeletePostCommentCommand>().ReverseMap();

			CreateMap<CreateLikePostDto, CreateLikePostCommand>().ReverseMap();
			CreateMap<CreateLikePostCommand, LikePost>().ReverseMap();
			CreateMap<UpdateLikePostDto, UpdateLikePostCommand>().ReverseMap();
			CreateMap<UpdateLikePostCommand, LikePost>().ReverseMap();
			CreateMap<DeleteLikePostDto, DeleteLikePostCommand>().ReverseMap();

			CreateMap<CreateFanpageByAdminDto, CreateFanpageByAdminCommand>().ReverseMap();
			CreateMap<CreateFanpageByAdminCommand, Fanpage>().ReverseMap();
			CreateMap<UpdateFanpageByAdminDto, UpdateFanpageByAdminCommand>().ReverseMap();
			CreateMap<UpdateFanpageByAdminCommand, Fanpage>().ReverseMap();

			CreateMap<CreateCensorOfFanpageDto, CreateCensorOfFanpageCommand>().ReverseMap();
			CreateMap<CreateCensorOfFanpageCommand, FanpageUser>().ReverseMap();
			CreateMap<UpdateCensorOfFanpageDto, UpdateCensorOfFanpageCommand>().ReverseMap();
			CreateMap<UpdateCensorOfFanpageCommand, FanpageUser>().ReverseMap();
			CreateMap<Fanpage, JoinFanpageUserDto>().ReverseMap();
			CreateMap<GetListFanpageByUserDto, GetListFanpageByUserQuery>().ReverseMap();
			CreateMap<GetListPostOfFanpageDto,GetListPostOfFanpageQuery>().ReverseMap();

			CreateMap<CreateGroupByAdminDto, CreateGroupByAdminCommand>().ReverseMap();
			CreateMap<CreateGroupByAdminCommand, Group>().ReverseMap();
			CreateMap<UpdateGroupByAdminDto, UpdateGroupByAdminCommand>().ReverseMap();
			CreateMap<UpdateGroupByAdminCommand, Group>().ReverseMap();

			CreateMap<CreateMemberOfGroupDto, CreateMemberOfGroupCommand>().ReverseMap();
			CreateMap<CreateMemberOfGroupCommand, GroupUser>().ReverseMap();
			CreateMap<UpdateMemberOfGroupDto, UpdateMemberOfGroupCommand>().ReverseMap();
			CreateMap<UpdateMemberOfGroupCommand, GroupUser>().ReverseMap();
			CreateMap<GetListGroupByUserDto, GetListGroupByUserQuery>().ReverseMap();
			CreateMap<GetListPostOfGroupDto, GetListPostOfGroupQuery>().ReverseMap();

			CreateMap<Friendship, SuggestionInformation>()
				.ForMember(x => x.ForeignId, opt => opt.MapFrom(src => src.FriendUserId))
				.ForMember(x => x.Name, opt => opt.MapFrom(src => src.FriendUserName))
				.ForMember(x => x.ImageUrl, opt => opt.MapFrom(src => src.FriendProfilePictureId));
			CreateMap<GetListSuggestionDto, GetListSuggestionQuery>().ReverseMap();
			CreateMap<CreateUserSelectionDto, CreateUserSelectionCommand>().ReverseMap();
			CreateMap<CreateUserSelectionCommand, Suggestion>().ReverseMap();

			CreateMap<GetListMemberOfGroupDto,GetListMemberOfGroupQuery>().ReverseMap();
			CreateMap<GetListCensorOfFanpageDto,GetListCensorOfFanpageQuery>().ReverseMap();
		}
	}
}
