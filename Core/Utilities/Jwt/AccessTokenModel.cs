namespace Core.Utilities.Jwt
{
    public class AccessTokenModel
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
    }
}
