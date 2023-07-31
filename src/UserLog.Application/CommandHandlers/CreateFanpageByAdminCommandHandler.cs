using App.Shared.AppSession;
using App.Shared.Uow;
using AutoMapper;
using MediatR;
using Swashbuckle.AspNetCore.SwaggerGen;
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
	public class CreateFanpageByAdminCommandHandler: IRequestHandler<CreateFanpageByAdminCommand, bool>
	{
		private readonly IFanpageRepository _fanpageRepository;
		private readonly IFanpageUserRepository _fanpageUserRepository;
		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IHomeMemberRepository _homeMemberRepository;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly IAppSession _appSession;
		public CreateFanpageByAdminCommandHandler(IFanpageRepository fanpageRepository, IFriendshipRepository friendshipRepository,
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

		public async Task<bool> Handle(CreateFanpageByAdminCommand command, CancellationToken cancellationToken)
		{
			var input = _mapper.Map<Fanpage>(command);
			input.TenantId = _appSession.TenantId;
			var fid = await _fanpageRepository.InsertAndGetIdAsync(input);
			var fu = new FanpageUser();
			fu.FanpageId = fid;
			fu.CensorId = command.CreatorId;
			fu.Permission = permission.Admin;
			_fanpageUserRepository.Insert(fu);
			if (command.CensorIds != null)
			{
				foreach (var item in command.CensorIds)
				{
					var censor = new FanpageUser();
					censor.Permission = permission.Censor; censor.CensorId = item;
					censor.FanpageId = fid;
					//censor.CensorId = item;
					await _fanpageUserRepository.InsertAsync(censor);
				}	
			}
			await _unitOfWork.SaveChangesAsync();

			return true;
		}
	}
}
