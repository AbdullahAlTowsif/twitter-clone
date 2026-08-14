namespace TwitterClone.Domain.Entities
{
    public class Tweet: BaseEntity
    {
        private Guid _userId;
        private string _content;

        public Tweet(string content): base(Guid.NewGuid())
        {
            _content = content;
        }

        public Guid AuthorId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
    }
}
