using Microsoft.EntityFrameworkCore;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence
{
    public class TwitterCloneDbContext: DbContext
    {
        public TwitterCloneDbContext(DbContextOptions<TwitterCloneDbContext> options): base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        // Runtime Polymorphism happening here
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TwitterCloneDbContext).Assembly);
        }
    }
}

/*
1. First add the entity in the TwitterCloneDbContext such as Tweet
2. Next model binding in Configurations folder such as TweetConfiguration
3. Now generate migrations
- dotnet ef migrations add <migration_name> --project TwitterClone.Infrastructure --startup-project TwitterClone.Api --output-dir Persistence/Migrations
 
*/