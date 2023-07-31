using App.Shared.AppSession;
using App.Shared.Uow;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.ICommands;
using UserLog.Domain.Repositories;

namespace UserLog.Application.CommandHandlers
{
	public class UpdateGroupByAdminCommandHandler: IRequestHandler<UpdateGroupByAdminCommand, bool>
	{
		private readonly IGroupRepository _groupRepository;
		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IHomeMemberRepository _homeMemberRepository;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly IAppSession _appSession;
		public UpdateGroupByAdminCommandHandler(IGroupRepository groupRepository, IFriendshipRepository friendshipRepository,
			IHomeMemberRepository homeMemberRepository, IMapper mapper, IAppSession appSession, IMaxUnitOfWork unitOfWork)
		{
			_groupRepository = groupRepository;
			_friendshipRepository = friendshipRepository;
			_homeMemberRepository = homeMemberRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_appSession = appSession;
		}

		public async Task<bool> Handle(UpdateGroupByAdminCommand command, CancellationToken cancellationToken)
		{
			var f = _groupRepository.FirstOrDefault(command.Id);
			if (f == null)
			{
				return false;
			}
			f.GroupName = command.GroupName;
			f.GroupProfilePictureUrl = command.GroupProfilePictureUrl;
			f.State = command.State;
			f.IsPublic = command.IsPublic;


			await _groupRepository.UpdateAsync(f);

			await _unitOfWork.SaveChangesAsync();

			return true;
		}
	}
}
