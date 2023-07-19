namespace HikiComic.ViewModels.Auth.VerifyDataRequest
{
    public class UserVerifyForgotPasswordRequest
    {
        public string Email { get; set; }

        public string OTP { get; set; }
    }
}
