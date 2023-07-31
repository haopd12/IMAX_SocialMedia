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
	public class UpdateCensorOfFanpageCommandHandler: IRequestHandler<UpdateCensorOfFanpageCommand, bool>
	{
		private readonly IFanpageUserRepository _fanpageUserRepository;
		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IHomeMemberRepository _homeMemberRepository;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly IAppSession _appSession;
		public UpdateCensorOfFanpageCommandHandler(IFanpageUserRepository fanpageUserRepository, IFriendshipRepository friendshipRepository,
			IHomeMemberRepository homeMemberRepository, IMapper mapper, IAppSession appSession, IMaxUnitOfWork unitOfWork)
		{
			_fanpageUserRepository = fanpageUserRepository;
			_friendshipRepository = friendshipRepository;
			_homeMemberRepository = homeMemberRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_appSession = appSession;
		}

		public async Task<bool> Handle(UpdateCensorOfFanpageCommand command, CancellationToken cancellationToken)
		{
			var f = _fanpageUserRepository.FirstOrDefault(command.Id);
			if (f == null)
			{
				return false;
			}
			f.Permission = command.Permission;
			f.CensorId = command.CensorId;


			await _fanpageUserRepository.UpdateAsync(f);

			await _unitOfWork.SaveChangesAsync();

			return true;
		}
	}
}
