namespace TwitterClone.Domain.Entities
{
    public class MentionNotification : Notification
    {
        public MentionNotification(Guid mentionedByUserId) : base("Mention")
        {
            MentionedByUserId = mentionedByUserId;
        }
        public Guid MentionedByUserId { get; set; }


        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord}, MentionedByUserId: {MentionedByUserId}";
        }

        public override string GetMessage()
        {
            return $"User with ID {MentionedByUserId} mentioned you in a post.";
        }

    }
}
