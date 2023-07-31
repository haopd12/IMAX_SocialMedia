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
	public class GetListCommentQueryHandler: IRequestHandler<GetListCommentQuery, PagedResultDto<PostComment>>
	{

		private readonly IPostCommentRepository _postCommentRepository;
		private readonly IAppSession _appSession;

		public GetListCommentQueryHandler(IAppSession appSession, IPostCommentRepository postCommentRepository)
		{

			_appSession = appSession;
			_postCommentRepository = postCommentRepository;
		}
		public Task<PagedResultDto<PostComment>> Handle(GetListCommentQuery request, CancellationToken cancellationToken)
		{
			var q = _postCommentRepository.GetAll()
				.Where(x => x.PostId == request.PostId)
				.Where(x => x.ParentCommentId == request.ParentCommentId);
			var list = q.Skip(request.SkipCount)
				.Take(request.MaxResultCount)
				.OrderByDescending(x => x.LastModificationTime)
				.ToList();
			var totalCount = list.Count();
			var result = new PagedResultDto<PostComment>()
			{
				TotalCount = totalCount,
				Items = list
			};
			return Task.FromResult(result);
		}
	}
}
