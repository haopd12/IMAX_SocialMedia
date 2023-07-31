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
	public class UpdateLikePostCommandHandler: IRequestHandler<UpdateLikePostCommand, bool>
	{
		private readonly ILikePostRepository _likePostRepository;
		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IHomeMemberRepository _homeMemberRepository;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly IAppSession _appSession;
		public UpdateLikePostCommandHandler(ILikePostRepository likePostRepository, IFriendshipRepository friendshipRepository,
			IHomeMemberRepository homeMemberRepository, IMapper mapper, IAppSession appSession, IMaxUnitOfWork unitOfWork)
		{
			_likePostRepository = likePostRepository;
			_friendshipRepository = friendshipRepository;
			_homeMemberRepository = homeMemberRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_appSession = appSession;
		}

		public async Task<bool> Handle(UpdateLikePostCommand command, CancellationToken cancellationToken)
		{
			var p = _likePostRepository.FirstOrDefault(x => x.Id == command.Id);

			if (p == null)
			{
				return false;
			}
			p.StateLike = command.StateLike;
			await _likePostRepository.UpdateAsync(p);

			await _unitOfWork.SaveChangesAsync();

			return true;
		}
	}
}
