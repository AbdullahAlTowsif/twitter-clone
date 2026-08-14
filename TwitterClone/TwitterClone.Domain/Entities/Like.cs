namespace TwitterClone.Domain.Entities
{
    public class Like
    {
        private Guid _id;
        private Guid _userId;
        private Guid _tweetId;
        private DateTime _likedAt;

        public Like(Guid userId, Guid tweetId)
        {
            _id = Guid.NewGuid();
            _userId = userId;
            _tweetId = tweetId;
            _likedAt = DateTime.UtcNow;
        }

        public Guid Id { get { return _id; } }
        public Guid UserId { get { return _userId; } }
        public Guid TweetId { get { return _tweetId; } }
        public DateTime LikedAt { get { return _likedAt; } }
    }
}
