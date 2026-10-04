using Microsoft.AspNetCore.Mvc;
using TwitterClone.Api.Data;
using TwitterClone.Api.Dtos;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwittersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly TweetRepository _tweetRepository;
        private readonly UserRepository _userRepository;

        public TwittersController(
            IConfiguration configuration,
            TweetRepository tweetRepository,
            UserRepository userRepository)
        {
            _configuration = configuration;
            _tweetRepository = tweetRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetTweets()
        {
            var tweets = _tweetRepository.GetTweets();

            return Ok(tweets.Select(ToDto));
        }

        [HttpGet("{id}")]
        public IActionResult GetTweetById([FromRoute] Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);

            if (tweet == null)
            {
                return NotFound();
            }

            return Ok(ToDto(tweet));
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetTweetsByUser([FromRoute] Guid userId)
        {
            var user = _userRepository.GetUserById(userId);

            if (user == null)
            {
                return NotFound("User not found!");
            }

            var tweets = _tweetRepository.GetTweetsByUserId(userId);

            return Ok(tweets.Select(ToDto));
        }

        [HttpPost]
        public IActionResult CreateTweet([FromBody] CreateTweetDto createTweetDto)
        {
            if (string.IsNullOrWhiteSpace(createTweetDto.Content))
            {
                return BadRequest("Content is required!");
            }

            var maxLength = _configuration.GetValue<int>("TwitterSettings:MaxTweetLength", Tweet.MaxContentLength);
            if (createTweetDto.Content.Length > maxLength)
            {
                return BadRequest($"Tweet cannot be longer than {maxLength} characters!");
            }

            var user = _userRepository.GetUserById(createTweetDto.UserId);
            if (user == null)
            {
                return NotFound("User not found!");
            }

            var createdTweet = _tweetRepository.AddTweet(
                new Tweet(createTweetDto.UserId, createTweetDto.Content));

            return CreatedAtAction(
                nameof(GetTweetById),
                new { id = createdTweet.Id },
                ToDto(createdTweet));
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTweet([FromRoute] Guid id, [FromBody] UpdateTweetDto updateTweetDto)
        {
            var tweet = _tweetRepository.GetTweetById(id);

            if (tweet == null)
            {
                return NotFound();
            }

            if (string.IsNullOrWhiteSpace(updateTweetDto.Content))
            {
                return BadRequest("Content is required!");
            }

            var maxLength = _configuration.GetValue<int>("TwitterSettings:MaxTweetLength", Tweet.MaxContentLength);
            if (updateTweetDto.Content.Length > maxLength)
            {
                return BadRequest($"Tweet cannot be longer than {maxLength} characters!");
            }

            tweet.Content = updateTweetDto.Content;
            _tweetRepository.UpdateTweet(tweet);

            return Ok(ToDto(tweet));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTweet([FromRoute] Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);

            if (tweet == null)
            {
                return NotFound();
            }

            var isDeleted = _tweetRepository.DeleteTweet(tweet);

            return Ok(isDeleted);
        }

        // Maps the entity to a DTO so the API never exposes the entity directly
        private static TweetDto ToDto(Tweet tweet)
        {
            return new TweetDto
            {
                Id = tweet.Id,
                UserId = tweet.UserId,
                Content = tweet.Content,
                CreatedAt = tweet.CreatedAt
            };
        }
    }
}
