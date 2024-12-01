namespace App.Infrastructure.Authentication
{
    public class JwtSettings
    {
        public const string SectionName = "JWT";
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInMinutes { get; set; }
    }
}
