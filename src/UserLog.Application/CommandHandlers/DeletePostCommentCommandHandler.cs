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
	public class DeletePostCommentCommandHandler: IRequestHandler<DeletePostCommentCommand, bool>
	{
		private readonly IPostCommentRepository _postCommentRepository;
		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IHomeMemberRepository _homeMemberRepository;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly IAppSession _appSession;
		public DeletePostCommentCommandHandler(IPostCommentRepository postCommentRepository, IFriendshipRepository friendshipRepository,
			IHomeMemberRepository homeMemberRepository, IMapper mapper, IAppSession appSession, IMaxUnitOfWork unitOfWork)
		{
			_postCommentRepository = postCommentRepository;
			_friendshipRepository = friendshipRepository;
			_homeMemberRepository = homeMemberRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_appSession = appSession;
		}
		public async Task<bool> Handle(DeletePostCommentCommand command, CancellationToken cancellationToken)
		{
			var post = _postCommentRepository.FirstOrDefault(command.Id);
			if (post == null)
			{
				return false;
			}
			await _postCommentRepository.DeleteAsync(post);
			return true;
		}
	}
}
