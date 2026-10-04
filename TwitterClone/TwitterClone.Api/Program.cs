using TwitterClone.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();   // generates the spec

// Repositories Registration
builder.Services.AddSingleton<UserRepository>();
builder.Services.AddSingleton<TweetRepository>();


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
