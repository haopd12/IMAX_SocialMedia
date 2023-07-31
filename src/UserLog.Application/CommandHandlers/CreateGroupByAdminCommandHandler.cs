using App.Shared.AppSession;
using App.Shared.Uow;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.Entities;
using UserLog.Domain.ICommands;
using UserLog.Domain.Repositories;

namespace UserLog.Application.CommandHandlers
{
	public class CreateGroupByAdminCommandHandler: IRequestHandler<CreateGroupByAdminCommand, bool>
	{
		private readonly IGroupRepository _groupRepository;
		private readonly IGroupUserRepository _groupUserRepository;
		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IHomeMemberRepository _homeMemberRepository;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly IAppSession _appSession;
		public CreateGroupByAdminCommandHandler(IGroupRepository groupRepository, IFriendshipRepository friendshipRepository,
			IHomeMemberRepository homeMemberRepository, IMapper mapper, IAppSession appSession, IMaxUnitOfWork unitOfWork, IGroupUserRepository groupUserRepository)
		{
			_groupRepository = groupRepository;
			_friendshipRepository = friendshipRepository;
			_homeMemberRepository = homeMemberRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_appSession = appSession;
			_groupUserRepository = groupUserRepository;
		}

		public async Task<bool> Handle(CreateGroupByAdminCommand command, CancellationToken cancellationToken)
		{
			var input = _mapper.Map<Group>(command);
			input.TenantId = _appSession.TenantId;
			var fid = await _groupRepository.InsertAndGetIdAsync(input);
			var fu = new GroupUser();
			fu.GroupId = fid;
			fu.MemberId = command.CreatorId;
			fu.Permission = permission.Admin;
			_groupUserRepository.Insert(fu);
			if (command.MemberIds != null)
			{
				foreach (var item in command.MemberIds)
				{
					var Member = new GroupUser();
					Member.Permission = permission.Member; Member.MemberId = item;
					Member.GroupId = fid;
					//Member.MemberId = item;
					await _groupUserRepository.InsertAsync(Member);
				}
			}
			await _unitOfWork.SaveChangesAsync();

			return true;
		}
	}
}
