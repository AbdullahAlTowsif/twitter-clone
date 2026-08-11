namespace TwitterClone.Domain.Entities
{
    public class Retweet
    {
        private Guid _id;
        private Guid _userId;
        private Guid _tweetId;
        private DateTime _retweetedAt;

        public Retweet(Guid userId, Guid tweetId)
        {
            _id = Guid.NewGuid();
            _userId = userId;
            _tweetId = tweetId;
            _retweetedAt = DateTime.UtcNow;
        }

        public Guid Id { get { return _id; } }
        public Guid UserId { get { return _userId; } }
        public Guid TweetId { get { return _tweetId; } }
        public DateTime RetweetedAt { get { return _retweetedAt; } }
    }
}
