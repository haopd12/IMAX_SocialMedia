using App.Shared.Repositories;
using UserLog.Domain.Entities;
using UserLog.Domain.Repositories;
using UserLog.Infrastructure.Contexts;

namespace UserLog.Infrastructure.Repositories
{
	public class LikePostRepository : RepositoryBase<UserLogContext, LikePost, long>, ILikePostRepository
	{
		public LikePostRepository(UserLogContext context) : base(context)
		{
		}
	}
}