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
	public class UpdateMemberOfGroupCommandHandler: IRequestHandler<UpdateMemberOfGroupCommand, bool>
	{
		private readonly IGroupUserRepository _groupUserRepository;
		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IHomeMemberRepository _homeMemberRepository;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly IAppSession _appSession;
		public UpdateMemberOfGroupCommandHandler(IGroupUserRepository groupUserRepository, IFriendshipRepository friendshipRepository,
			IHomeMemberRepository homeMemberRepository, IMapper mapper, IAppSession appSession, IMaxUnitOfWork unitOfWork)
		{
			_groupUserRepository = groupUserRepository;
			_friendshipRepository = friendshipRepository;
			_homeMemberRepository = homeMemberRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_appSession = appSession;
		}

		public async Task<bool> Handle(UpdateMemberOfGroupCommand command, CancellationToken cancellationToken)
		{
			var f = _groupUserRepository.FirstOrDefault(command.Id);
			if (f == null)
			{
				return false;
			}
			f.Permission = command.Permission;
			f.State = command.State;


			await _groupUserRepository.UpdateAsync(f);

			await _unitOfWork.SaveChangesAsync();

			return true;
		}
	}
}
