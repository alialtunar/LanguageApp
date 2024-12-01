namespace App.Application.Feautures.Auth.Dto
{
    public class AuthenticationResultDto
    {
        public string Message { get; init; }
        public bool IsAuthenticated { get; init; }
        public string UserName { get; init; }
        public string Email { get; init; }
        public List<string> Roles { get; init; }
        public string Token { get; init; }
    }
}
