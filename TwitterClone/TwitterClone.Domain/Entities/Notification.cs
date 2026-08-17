namespace TwitterClone.Domain.Entities
{
    public abstract class Notification: BaseEntity
    {
        private Guid _userId; // the user who gets the notification
        private string _type;
        private string _message;
        private bool _isRead;

        public Notification(string nofificationType): base(Guid.NewGuid())
        {
            _type = nofificationType;
        }

        public Guid UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        protected string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public bool IsRead
        {
            get { return _isRead; }
            set { _isRead = value; }
        }

        public string GetNotificationInfo()
        {
            return $"UserId: {UserId}, Notification Type: {_type}";
        }

        public override string DescribeRecord()
        {
            return $"Notification Class: Notification Type: {Type}, Message: {Message}, IsRead: {IsRead}";
        }

        public abstract string GetMessage();
    }
}
