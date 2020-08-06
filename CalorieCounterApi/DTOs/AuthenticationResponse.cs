
namespace CalorieCounterApi.DTOs
{
    public class AuthenticationResponse
    {
        public AuthenticationResponse(string accessToken, string userId)
        {
            AccessToken = accessToken;
            UserId = userId;
            TokenType = "Bearer";
        }

        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public string RefreshToken { get; set; }
        public string UserId { get; set; }
    }
}