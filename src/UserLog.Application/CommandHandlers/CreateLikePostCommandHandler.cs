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
	public class CreateLikePostCommandHandler: IRequestHandler<CreateLikePostCommand, bool>
	{
		private readonly ILikePostRepository _likePostRepository;
		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IHomeMemberRepository _homeMemberRepository;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly IAppSession _appSession;
		public CreateLikePostCommandHandler(ILikePostRepository likePostRepository, IFriendshipRepository friendshipRepository,
			IHomeMemberRepository homeMemberRepository, IMapper mapper, IAppSession appSession, IMaxUnitOfWork unitOfWork)
		{
			_likePostRepository = likePostRepository;
			_friendshipRepository = friendshipRepository;
			_homeMemberRepository = homeMemberRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_appSession = appSession;
		}

		public async Task<bool> Handle(CreateLikePostCommand command, CancellationToken cancellationToken)
		{
			var input = _mapper.Map<LikePost>(command);
			input.TenantId = _appSession.TenantId;


			var id = await _likePostRepository.InsertAndGetIdAsync(input);

			await _unitOfWork.SaveChangesAsync();

			return true;
		}
	}
}
