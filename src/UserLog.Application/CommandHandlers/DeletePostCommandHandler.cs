using App.Shared.AppSession;
using App.Shared.Uow;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.ICommands;
using UserLog.Domain.Repositories;

namespace UserLog.Application.CommandHandlers
{
	public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, bool>
	{
		private readonly IPostRepository _postRepository;
		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IHomeMemberRepository _homeMemberRepository;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly IAppSession _appSession;
		public DeletePostCommandHandler(IPostRepository postRepository, IFriendshipRepository friendshipRepository,
			IHomeMemberRepository homeMemberRepository, IMapper mapper, IAppSession appSession, IMaxUnitOfWork unitOfWork)
		{
			_postRepository = postRepository;
			_friendshipRepository = friendshipRepository;
			_homeMemberRepository = homeMemberRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_appSession = appSession;
		}
		public async Task<bool> Handle(DeletePostCommand command, CancellationToken cancellationToken)
		{
			var post = _postRepository.FirstOrDefault(command.Id);
			if (post == null)
			{
				return false;
			}
			await _postRepository.DeleteAsync(post);
			return true;
		}
	}
}
