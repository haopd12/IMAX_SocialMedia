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
	public class DeleteFanpageByAdminCommandHandler: IRequestHandler<DeleteFanpageByAdminCommand, bool>
	{
		private readonly IFanpageRepository _fanpageRepository;
		private readonly IFanpageUserRepository _fanpageUserRepository;
		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IHomeMemberRepository _homeMemberRepository;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly IAppSession _appSession;
		public DeleteFanpageByAdminCommandHandler(IFanpageRepository fanpageRepository, IFriendshipRepository friendshipRepository,
			IHomeMemberRepository homeMemberRepository, IMapper mapper, IAppSession appSession, IMaxUnitOfWork unitOfWork, IFanpageUserRepository fanpageUserRepository)
		{
			_fanpageRepository = fanpageRepository;
			_friendshipRepository = friendshipRepository;
			_homeMemberRepository = homeMemberRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_appSession = appSession;
			_fanpageUserRepository = fanpageUserRepository;
		}

		public async Task<bool> Handle(DeleteFanpageByAdminCommand command, CancellationToken cancellationToken)
		{
			var f = _fanpageRepository.FirstOrDefault(command.Id);
			if (f == null)
			{
				return false;
			}
			var fu = _fanpageUserRepository.GetAll()
				.Where(x => x.FanpageId == command.Id)
				.ToList();
			foreach (var u in fu)
			{
				await _fanpageUserRepository.DeleteAsync(u);
			}
			await _fanpageRepository.DeleteAsync(f);
			await _unitOfWork.SaveChangesAsync();

			return true;
		}
	}
}
