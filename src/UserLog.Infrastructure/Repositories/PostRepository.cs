using App.Shared.Repositories;
using UserLog.Domain.Entities;
using UserLog.Domain.Repositories;
using UserLog.Infrastructure.Contexts;

namespace UserLog.Infrastructure.Repositories
{
	public class PostRepository: RepositoryBase<UserLogContext, Post, long>, IPostRepository
	{
		public PostRepository(UserLogContext context) : base(context)
		{
		}
	}
}
