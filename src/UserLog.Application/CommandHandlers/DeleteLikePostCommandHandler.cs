﻿using App.Shared.AppSession;
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
	public class DeleteLikePostCommandHandler: IRequestHandler<DeleteLikePostCommand, bool>
	{
		private readonly ILikePostRepository _likePostRepository;
		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IHomeMemberRepository _homeMemberRepository;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly IAppSession _appSession;
		public DeleteLikePostCommandHandler(ILikePostRepository likePostRepository, IFriendshipRepository friendshipRepository,
			IHomeMemberRepository homeMemberRepository, IMapper mapper, IAppSession appSession, IMaxUnitOfWork unitOfWork)
		{
			_likePostRepository = likePostRepository;
			_friendshipRepository = friendshipRepository;
			_homeMemberRepository = homeMemberRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_appSession = appSession;
		}
		public async Task<bool> Handle(DeleteLikePostCommand command, CancellationToken cancellationToken)
		{
			var likePost = _likePostRepository.FirstOrDefault(command.Id);
			if (likePost == null)
			{
				return false;
			}
			await _likePostRepository.DeleteAsync(likePost);
			return true;
		}
	}
}
