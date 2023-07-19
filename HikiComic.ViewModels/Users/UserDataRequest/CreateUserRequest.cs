using System.ComponentModel.DataAnnotations;

namespace HikiComic.ViewModels.Users.UserDataRequest
{
    public class CreateUserRequest
    {
        public string Email { get; set; } = null!;

        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
