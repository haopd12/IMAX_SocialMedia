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
	public class GetListSharedPostQueryHandler: IRequestHandler<GetListSharedPostQuery, PagedResultDto<Post>>
	{

		private readonly IPostRepository _postRepository;
		private readonly IAppSession _appSession;

		public GetListSharedPostQueryHandler(IAppSession appSession, IPostRepository postRepository)
		{

			_appSession = appSession;
			_postRepository = postRepository;
		}
		public Task<PagedResultDto<Post>> Handle(GetListSharedPostQuery request, CancellationToken cancellationToken)
		{
			var q = _postRepository.GetAll()
				.Where(x => x.SharedPostId == request.SharedId);
			
			var list = q.ToList();
			
			var result = new PagedResultDto<Post>()
			{
				TotalCount = list.Count(),
				Items = list
			};
			return Task.FromResult(result);
		}
	}
}
