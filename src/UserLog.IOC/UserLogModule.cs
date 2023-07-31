using App.Shared.Uow;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLog.Application.QueryHandlers;
using UserLog.Domain.Repositories;
using UserLog.Infrastructure.Contexts;
using UserLog.Infrastructure.Repositories;


namespace UserLog.IOC
{
	public static class UserLogModule
	{
		public static void Register(this IServiceCollection services)
		{
			services.AddScoped<IFriendshipRepository, FriendshipRepository>();
			services.AddScoped<IHomeMemberRepository, HomeMemberRepository>();
			services.AddScoped<ILikePostRepository, LikePostRepository>();
			services.AddScoped<IPostRepository, PostRepository>();
			services.AddScoped<IPostCommentRepository, PostCommentRepository>();
			services.AddScoped<IFanpageRepository, FanpageRepository>();
			services.AddScoped<IFanpageUserRepository, FanpageUserRepository>();
			services.AddScoped<IGroupRepository, GroupRepository>();
			services.AddScoped<IGroupUserRepository, GroupUserRepository>();
			services.AddScoped<ISuggestionRepository, SuggestionRepository>();

			services.AddScoped<IMaxUnitOfWork, UnitOfWork>();
			AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


			services.AddMediatR(typeof(GetListPostQueryHandler));
			services.AddMediatR(typeof(GetListFriendshipQueryHandler));
			services.AddMediatR(typeof(GetListGroupByUserQueryHandler));

		}
		public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<UserLogContext>(opt =>
				opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
			services.AddDbContext<RelationshipContext>(otp =>
				otp.UseSqlServer(configuration.GetConnectionString("SqlServerConnection")));
			services.AddScoped<IImaxDbConext, UserLogContext>();
			services.AddScoped<IImaxDbConext, RelationshipContext>();
		}
	}
}
