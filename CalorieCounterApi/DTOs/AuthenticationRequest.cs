namespace CalorieCounterApi.DTOs
{
    public class AuthenticationRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string GrantType { get; set; }
        public string Scope { get; set; }
    }
}