namespace HikiComic.ViewModels.Accounts.AccountDataRequest
{
    public class ResetPasswordRequest
    {
        public string Email { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
