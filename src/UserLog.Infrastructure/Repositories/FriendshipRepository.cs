using App.Shared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UserLog.Domain.Entities;
using UserLog.Domain.Repositories;
using UserLog.Infrastructure.Contexts;

namespace UserLog.Infrastructure.Repositories
{
	public class FriendshipRepository: RepositoryBase<RelationshipContext,Friendship,long>, IFriendshipRepository
	{
		public FriendshipRepository(RelationshipContext context) : base(context) { }
	}
}
