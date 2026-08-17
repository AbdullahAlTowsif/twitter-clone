namespace TwitterClone.Domain.Entities
{
    // sealed: no one can inherit LikeNotification Class
    public sealed class LikeNotification: Notification
    {
        public LikeNotification(Guid likeByUserId): base("Like")
        {
            LikeByUserId = likeByUserId;
        }
        // kon user ta like korse
        public Guid LikeByUserId { get; set; }

        public void AddMessage(string message)
        {
            Message = message;
        }

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"BaseRecord: {baseRecord} - Notification Type: {Type}, Message: {Message}, IsRead: {IsRead}, LikeByUserId: {LikeByUserId}";
        }

        public override string GetMessage()
        {
            return $"User with ID {LikeByUserId} liked your post";
        }
    }
}
