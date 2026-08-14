namespace TwitterClone.Domain.Entities
{
    public class Follow
    {
        private Guid _id;
        private Guid _followerId;
        private Guid _followingId;
        private DateTime _followedAt;

        public Follow(Guid followerId, Guid followingId)
        {
            _id = Guid.NewGuid();
            _followerId = followerId;
            _followingId = followingId;
            _followedAt = DateTime.UtcNow;
        }

        public Guid Id { get { return _id; } }
        public Guid FollowerId { get { return _followerId; } }   // the user who follows
        public Guid FollowingId { get { return _followingId; } } // the user being followed
        public DateTime FollowedAt { get { return _followedAt; } }
    }
}
