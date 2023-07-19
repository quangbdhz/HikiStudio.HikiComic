namespace HikiComic.ViewModels.Auth.Token
{
    public class RefreshTokenViewModel
    {
        public string RefreshToken { get; set; } = string.Empty;

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Expires { get; set; }
    }
}
