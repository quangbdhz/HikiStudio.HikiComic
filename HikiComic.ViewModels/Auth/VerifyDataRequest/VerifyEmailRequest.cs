namespace HikiComic.ViewModels.Auth.VerifyDataRequest
{
    public class VerifyEmailRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string OTP { get; set; }
    }
}
