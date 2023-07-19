using System.ComponentModel.DataAnnotations;

namespace HikiComic.ViewModels.Users.UserDataRequest
{
    public class UserLoginRequest
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public bool RememberMe { get; set; }
    }
}
