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
	public class DeleteMemberOfGroupCommandHandler: IRequestHandler<DeleteMemberOfGroupCommand, bool>
	{
		private readonly IGroupRepository _groupRepository;
		private readonly IGroupUserRepository _groupUserRepository;
		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IHomeMemberRepository _homeMemberRepository;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly IAppSession _appSession;
		public DeleteMemberOfGroupCommandHandler(IGroupRepository groupRepository, IFriendshipRepository friendshipRepository,
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

		public async Task<bool> Handle(DeleteMemberOfGroupCommand command, CancellationToken cancellationToken)
		{
			var f = _groupUserRepository.FirstOrDefault(command.Id);

			await _groupUserRepository.DeleteAsync(f);
			await _unitOfWork.SaveChangesAsync();

			return true;
		}
	}
}
