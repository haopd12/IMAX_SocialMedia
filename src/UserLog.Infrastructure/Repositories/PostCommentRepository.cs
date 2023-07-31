using App.Shared.Repositories;
using UserLog.Domain.Entities;
using UserLog.Domain.Repositories;
using UserLog.Infrastructure.Contexts;

namespace UserLog.Infrastructure.Repositories
{
	public class PostCommentRepository: RepositoryBase<UserLogContext, PostComment, long>, IPostCommentRepository
	{
		public PostCommentRepository(UserLogContext context) : base(context)
		{
		}
	}
}
