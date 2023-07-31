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
	public class CreatePostCommentCommandHandler: IRequestHandler<CreatePostCommentCommand, bool>
	{
		private readonly IPostCommentRepository _postCommentRepository;
		private readonly IFriendshipRepository _friendshipRepository;
		private readonly IHomeMemberRepository _homeMemberRepository;
		private readonly IMapper _mapper;
		private readonly IMaxUnitOfWork _unitOfWork;
		private readonly IAppSession _appSession;
		public CreatePostCommentCommandHandler(IPostCommentRepository postCommentRepository, IFriendshipRepository friendshipRepository,
			IHomeMemberRepository homeMemberRepository, IMapper mapper, IAppSession appSession, IMaxUnitOfWork unitOfWork)
		{
			_postCommentRepository = postCommentRepository;
			_friendshipRepository = friendshipRepository;
			_homeMemberRepository = homeMemberRepository;
			_mapper = mapper;
			_unitOfWork = unitOfWork;
			_appSession = appSession;
		}

		public async Task<bool> Handle(CreatePostCommentCommand command, CancellationToken cancellationToken)
		{
			var input = _mapper.Map<PostComment>(command);
			input.TenantId = _appSession.TenantId;

			await _postCommentRepository.InsertAsync(input);

			await _unitOfWork.SaveChangesAsync();

			return true;
		}
	}
}

