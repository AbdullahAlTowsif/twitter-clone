namespace TwitterClone.Api.Dtos
{
    public class CreateTweetDto
    {
        public Guid UserId { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
