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
	public class UpdatePostCommandHandler: IRequestHandler<UpdatePostCommand, bool>
	{
		private readonly IPostRepository _postRepository;
		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IHomeMemberRepository _homeMemberRepository;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly IAppSession _appSession;
		public UpdatePostCommandHandler(IPostRepository postRepository, IFriendshipRepository friendshipRepository,
			IHomeMemberRepository homeMemberRepository, IMapper mapper, IAppSession appSession, IMaxUnitOfWork unitOfWork)
		{
			_postRepository = postRepository;
			_friendshipRepository = friendshipRepository;
			_homeMemberRepository = homeMemberRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_appSession = appSession;
		}

		public async Task<bool> Handle(UpdatePostCommand command, CancellationToken cancellationToken)
		{
			var post = _postRepository.FirstOrDefault(command.Id);
			if (post == null)
			{
				return false;
			}
			post.ContentPost = command.ContentPost;
			post.State = command.State;
			post.FeedbackId = command.FeedbackId;
			post.ImageUrls = command.ImageUrls;
			post.State = command.State;
			post.TagFriendIds = command.TagFriendIds;
			
			await _postRepository.UpdateAsync(post);

			await _unitOfWork.SaveChangesAsync();

			return true;
		}
	}
}
