using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Data
{
    public class TweetRepository
    {
        private readonly List<Tweet> _tweets = new List<Tweet>();

        public List<Tweet> GetTweets()
        {
            return _tweets;
        }

        public List<Tweet> GetTweetsByUserId(Guid userId)
        {
            return _tweets.Where(t => t.UserId == userId).ToList();
        }

        public Tweet? GetTweetById(Guid id)
        {
            return _tweets.FirstOrDefault(t => t.Id == id);
        }

        public Tweet AddTweet(Tweet tweet)
        {
            _tweets.Add(tweet);
            return tweet;
        }

        public Tweet UpdateTweet(Tweet tweet)
        {
            // The tweet object is already in the list, so changes are saved.
            // With a real database, this is where you'd call SaveChanges.
            _tweets.RemoveAll(t => t.Id == tweet.Id);
            _tweets.Add(tweet);
            return tweet;
        }

        public bool DeleteTweet(Tweet tweet)
        {
            return _tweets.Remove(tweet);
        }
    }
}

