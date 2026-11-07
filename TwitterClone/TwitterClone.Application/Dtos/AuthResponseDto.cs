namespace TwitterClone.Application.Dtos
{
    public class AuthResponseDto
    {
        public required string AccessToken { get; set; }
        public DateOnly ExpiryAt { get; set; }
        public required UserDto UserDto { get; set; }
    }
}
