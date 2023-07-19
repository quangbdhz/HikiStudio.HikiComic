using System.ComponentModel.DataAnnotations;

namespace HikiComic.ViewModels.Users.UserDataRequest
{
    public class UserRegisterRequest
    {
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password does not match")]
        public string ConfirmPassword { get; set; } = null!;
    }
}
