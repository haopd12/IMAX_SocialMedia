using AppShared.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.Entities;

namespace UserLog.Domain.Repositories
{
	public interface IHomeMemberRepository: IRepository<HomeMember, long>
	{
	}
}
