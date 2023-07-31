using App.Shared.AppSession;
using App.Shared.Uow;

namespace UserLog.Infrastructure.Contexts;

public class UnitOfWork : UnitOfWorkBase<UserLogContext>, IMaxUnitOfWork
{
    public UnitOfWork(UserLogContext context) : base(context)
    {
    }
}