using System.ComponentModel.DataAnnotations;

namespace TwitterClone.Application.Dtos
{
    public class UpdateTweetDto
    {
        [Required]
        public required string Content { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return TweetContentValidator.Validate(Content, nameof(Content));
        }
    }
}
