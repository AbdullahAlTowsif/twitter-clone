using Microsoft.Extensions.DependencyInjection;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Services;

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

namespace TwitterClone.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITweetService, TweetService>();
            services.AddScoped<IBookmarkService, BookmarkService>();
            services.AddScoped<IFollowService, FollowService>();
            services.AddScoped<ILikeService, LikeService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IRetweetService, RetweetService>();

            // Amra application layer e auth service k register korsi. Karon interface ta o application layer e ache. AuthService o ache application layer e.
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
