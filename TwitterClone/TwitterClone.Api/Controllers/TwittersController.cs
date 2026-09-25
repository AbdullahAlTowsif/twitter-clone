using Microsoft.AspNetCore.Mvc;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwittersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TwittersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetTweets()
        {
            var maxLength = _configuration.GetValue<int>("TwitterSettings:MaxTweetLength");
            var appName = _configuration.GetValue<string>("TwitterSettings:AppName");

            var tweets = new List<Tweet>
            {
                new Tweet(Guid.NewGuid(), "Hello, world!"),
                new Tweet(Guid.NewGuid(), "This is a tweet."),
                new Tweet(Guid.NewGuid(), "Another tweet here.")
            };

            return Ok(new
            {
                appName,
                maxLength,
                tweets
            });
        }
    }
}
