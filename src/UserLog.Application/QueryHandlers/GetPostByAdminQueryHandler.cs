using App.Shared.AppSession;
using App.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.Entities;
using UserLog.Domain.IQueries;
using UserLog.Domain.Repositories;

namespace UserLog.Application.QueryHandlers
{
	public class GetPostByAdminQueryHandler: IRequestHandler<GetPostByAdminQuery, Post>
	{

		private readonly IPostRepository _postRepository;
		private readonly IAppSession _appSession;

		public GetPostByAdminQueryHandler(IAppSession appSession, IPostRepository postRepository)
		{

			_appSession = appSession;
			_postRepository = postRepository;
		}
		public Task<Post> Handle(GetPostByAdminQuery request, CancellationToken cancellationToken)
		{
			var q = _postRepository.FirstOrDefault(x => x.Id == request.Id);
			if (q == null)
				return null;
			
			return Task.FromResult(q);
		}
	}
}
