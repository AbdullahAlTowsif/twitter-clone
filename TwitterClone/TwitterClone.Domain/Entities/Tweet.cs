namespace TwitterClone.Domain.Entities
{
    public class Tweet: BaseEntity, ILikeable
    {
        private Guid _userId;
        private string _content;

        public static int MaxContentLength = 280; // Static member

        // Constructor Overloading: Same constructor name but different behaviour (Polymorphism here)
        // constructor1
        public Tweet(string content): base(Guid.NewGuid())
        {
            _content = content;
        }

        // constructor2
        public Tweet(Guid userId, string content) : base(Guid.NewGuid())
        {
            _userId = userId;
            _content = content;
        }

        public Guid UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        // Method Overloading: Same method name but different parament (Polymorphism here)
        // Method1
        public void AddContent(string content)
        {
            _content = content;
        }

        // Method2
        public void AddContent(Guid userId, string content)
        {
            _userId = userId;
            _content = content;
        }

        public override string DescribeRecord()
        {
            var baseRecord = base.DescribeRecord();
            return $"{baseRecord} - UserId: {UserId}, Content: {Content}";
        }

        public bool CanBeLiked()
        {
            return true;
        }
    }
}
