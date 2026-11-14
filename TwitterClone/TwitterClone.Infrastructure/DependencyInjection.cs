using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TwitterClone.Application.Interfaces;
using TwitterClone.Infrastructure.Auth;
using TwitterClone.Infrastructure.Persistence;
using TwitterClone.Infrastructure.Repositories;

/*
 DotNet Object Lifetime (3 types):
1. AddScoped: Per Request -> Suppose for UserRepository a create request came -> so one instance for UserRepo.
- One instance is created per client request or dependency scope (e.g., once per HTTP request in ASP.NET Core).
2. AddSingleton: Kono application lifetime e ekta object ei thakbe.
- A single instance is created the first time it is requested (or when provided directly) and shared everywhere.
3. AddTransient: A new instance is created every time the service is requested.


----- Where to register -----
Amra application layer e auth service k register korsi. Karon interface ta o application layer e ache. AuthService o ache application layer e.
Kintu ITokenService application layer e ache it's fine but etar implementation ache infrastructure layer e.
implementation jehetun infrastructure layer e achi amake eita register korte hbe Infrastrucre layer e.

--> Jehetu register kora hoise eder instance ami jkhono controller e inject korle pabo.
 */

namespace TwitterClone.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Singletons because the repositories keep their data in memory.
            // Switch to scoped when they are backed by a real database (e.g. EF Core DbContext).
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            if(string.IsNullOrWhiteSpace(connectionString))
            {
                throw new Exception("Database connection string is not found!");
            }

            services.AddDbContext<TwitterCloneDbContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITweetRepository, TweetRepository>();
            services.AddScoped<IBookmarkRepository, BookmarkRepository>();
            services.AddScoped<IFollowRepository, FollowRepository>();
            services.AddScoped<ILikeRepository, LikeRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IRetweetRepository, RetweetRepository>();

            // ITokenService application layer e ache it's fine but etar implementation ache infrastructure layer e. Implementation jehetun infrastructure layer e achi amake eita register korte hbe Infrastrucre layer e.
            services.AddScoped<ITokenService, JwtTokenService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            return services;
        }
    }
}
