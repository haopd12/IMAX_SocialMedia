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
	public class UpdatePostCommentCommandHandler: IRequestHandler<UpdatePostCommentCommand, bool>
	{
		private readonly IPostCommentRepository _postCommentRepository;
		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IHomeMemberRepository _homeMemberRepository;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly IAppSession _appSession;
		public UpdatePostCommentCommandHandler(IPostCommentRepository postCommentRepository, IFriendshipRepository friendshipRepository,
			IHomeMemberRepository homeMemberRepository, IMapper mapper, IAppSession appSession, IMaxUnitOfWork unitOfWork)
		{
			_postCommentRepository = postCommentRepository;
			_friendshipRepository = friendshipRepository;
			_homeMemberRepository = homeMemberRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_appSession = appSession;
		}

		public async Task<bool> Handle(UpdatePostCommentCommand command, CancellationToken cancellationToken)
		{
			var post = _postCommentRepository.FirstOrDefault(command.Id);
			if (post == null)
			{
				return false;
			}
			post.Comment = command.Comment;

			await _postCommentRepository.UpdateAsync(post);

			await _unitOfWork.SaveChangesAsync();

			return true;
		}
	}
}
