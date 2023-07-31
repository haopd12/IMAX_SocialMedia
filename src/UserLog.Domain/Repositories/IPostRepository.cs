using AppShared.Repositories;
using UserLog.Domain.Entities;

namespace UserLog.Domain.Repositories;

public interface IPostRepository : IRepository<Post, long>
{
}