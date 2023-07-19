namespace HikiComic.ViewModels.Users.UserDataRequest
{
    public class VerifyTokenEmailAndChangePasswordRequest
    {
        public string Token { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
