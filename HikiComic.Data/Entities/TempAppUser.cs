namespace HikiComic.Data.Entities
{
    public class TempAppUser
    {
        public int TempAppUserId { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string? OTP { get; set; }

        public DateTime? OTPExpires { get; set; }
    }
}
