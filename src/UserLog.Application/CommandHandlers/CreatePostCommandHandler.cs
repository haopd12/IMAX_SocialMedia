﻿using App.Shared.AppSession;
using App.Shared.Uow;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
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
	public class CreatePostCommandHandler: IRequestHandler<CreatePostCommand, bool>
	{
		private readonly IPostRepository _postRepository;
		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IHomeMemberRepository _homeMemberRepository;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly IAppSession _appSession;
		public CreatePostCommandHandler(IPostRepository postRepository, IFriendshipRepository friendshipRepository, 
			IHomeMemberRepository homeMemberRepository, IMapper mapper, IAppSession appSession, IMaxUnitOfWork unitOfWork)
		{
			_postRepository = postRepository;
			_friendshipRepository = friendshipRepository;
			_homeMemberRepository = homeMemberRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_appSession = appSession;
		}

		public async Task<bool> Handle(CreatePostCommand command, CancellationToken cancellationToken)
		{
			var input = _mapper.Map<Post>(command);
			input.TenantId = _appSession.TenantId;

			
			var id = await _postRepository.InsertAndGetIdAsync(input);

			await _unitOfWork.SaveChangesAsync();

			return true;
		}	
	}
}
