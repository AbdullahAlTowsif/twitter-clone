using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Services;
using TwitterClone.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();   // generates the spec

// Repositories & Service Registration
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddSingleton<ITweetRepository, TweetRepository>();
builder.Services.AddScoped<ITweetService, TweetService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();            // spec at /openapi/v1.json
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "TwitterClone API v1");
        options.RoutePrefix = "swagger";   // UI at /swagger
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

/*

 Clean Architecture
4 layers of Clean Architecture:
1. Domain (Class Library Project): What our business is e.g. User, Tweet, Comment, Like, Follow --> Entities, Enums, Domain Rules etc.
2. Application (Class Library Project): What our application does basically use cases e.g. CreateTweet, GetTweet --> services, DTOs, repository interface etc.
3. Infrastructure (Class Library Project): External communication business like communicating with database e.g. Repositories, Email or any other third party communication.
Note: We have repositories both in Application and Infrastructure layer so there might arise a confusion. Repository class or Implementation are in Infrastructure layer but Repository Interface are in Application layer. That's the main difference.
4. API (Web API Project): How users communicate with our application e.g. Controller (Receive HTTP Request -> Call Application -> Return HTTP response)

The Dependency Rule:
Domain (Totally Independent) <-- Application <-- API <-- Infrastructure

 */
