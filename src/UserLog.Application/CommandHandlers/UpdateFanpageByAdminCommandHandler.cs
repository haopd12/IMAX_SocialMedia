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
	public class UpdateFanpageByAdminCommandHandler: IRequestHandler<UpdateFanpageByAdminCommand, bool>
	{
		private readonly IFanpageRepository _fanpageRepository;
		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IHomeMemberRepository _homeMemberRepository;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly IAppSession _appSession;
		public UpdateFanpageByAdminCommandHandler(IFanpageRepository fanpageRepository, IFriendshipRepository friendshipRepository,
			IHomeMemberRepository homeMemberRepository, IMapper mapper, IAppSession appSession, IMaxUnitOfWork unitOfWork)
		{
			_fanpageRepository = fanpageRepository;
			_friendshipRepository = friendshipRepository;
			_homeMemberRepository = homeMemberRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_appSession = appSession;
		}

		public async Task<bool> Handle(UpdateFanpageByAdminCommand command, CancellationToken cancellationToken)
		{
			var f = _fanpageRepository.FirstOrDefault(command.Id);
			if (f == null)
			{
				return false;
			}
			f.FanpageName = command.FanpageName;
			f.FanpageProfilePictureUrl = command.FanpageProfilePictureUrl;
			f.State = command.State;


			await _fanpageRepository.UpdateAsync(f);

			await _unitOfWork.SaveChangesAsync();

			return true;
		}
	}
}
