using Abp.Collections.Extensions;
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
	public class GetListLikePostQueryHandler: IRequestHandler<GetListLikePostQuery, PagedResultDto<LikePost>>
	{

		private readonly ILikePostRepository _likePostRepository;
		private readonly IAppSession _appSession;

		public GetListLikePostQueryHandler(IAppSession appSession, ILikePostRepository likePostRepository)
		{

			_appSession = appSession;
			_likePostRepository = likePostRepository;
		}
		public Task<PagedResultDto<LikePost>> Handle(GetListLikePostQuery request, CancellationToken cancellationToken)
		{
			var q = _likePostRepository.GetAll()
				.Where(x => x.PostId == request.PostId)
				.Where(x => x.CommentId == request.CommentId)
				.WhereIf(request.StateLike.HasValue, x => x.StateLike == request.StateLike);
			var list = q.ToList();
			var totalCount = list.Count();
			var result = new PagedResultDto<LikePost>()
			{
				TotalCount = totalCount,
				Items = list
			};
			return Task.FromResult(result);
		}
	}
}
