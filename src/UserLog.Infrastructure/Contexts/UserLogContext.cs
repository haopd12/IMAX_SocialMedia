using App.Shared.AppSession;
using App.Shared.Uow;
using Microsoft.EntityFrameworkCore;

using UserLog.Domain.Entities;

namespace UserLog.Infrastructure.Contexts;

public class UserLogContext : ImaxDbContextBase<UserLogContext>
{
	public virtual DbSet<Fanpage> Fanpages { get; set; }
	public virtual DbSet<FanpageUser> FanpageUsers { get; set; }
	public virtual DbSet<LikePost>? LikePosts { get; set; }
    public virtual DbSet<Post>? Posts { get; set; }
	public virtual DbSet<PostComment>? PostComments { get; set; }
	public virtual DbSet<GroupUser> GroupUsers { get; set; }
	public virtual DbSet<Group> Groups { get; set; }
	public virtual DbSet<Suggestion> DeniedSuggestions { get; set; }
	public UserLogContext(DbContextOptions<UserLogContext> options, IAppSession appSession) : base(options, appSession)
    {
    }
	/*
		 protected override void OnModelCreating(ModelBuilder modelBuilder)
		 {
			modelBuilder.Entity<Work>()
				.HasKey(x => x.Id)

		 }*/
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		var mutableProperties = modelBuilder.Model.GetEntityTypes()
			.SelectMany(e => e.GetProperties().Where(p => p.ClrType == typeof(string)));

		modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserLogContext).Assembly);
		base.OnModelCreating(modelBuilder);
		modelBuilder.HasDefaultSchema("social_media");
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql("DefaultConnection");
        }
    }
}