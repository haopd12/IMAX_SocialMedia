using App.Shared.AppSession;
using App.Shared.Uow;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Domain.Entities;

namespace UserLog.Infrastructure.Contexts
{
	public class RelationshipContext: ImaxDbContextBase<RelationshipContext>
	{
		public virtual DbSet<Friendship>? Friendships { get; set; }
		public virtual DbSet<HomeMember>? HomeMembers { get; set; }

		public RelationshipContext(DbContextOptions<RelationshipContext> options, IAppSession appSession) : base(options, appSession)
		{
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("SqlServerConnection");
			}
		}
	}
}
