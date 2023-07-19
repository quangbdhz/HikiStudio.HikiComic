using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HikiComic.ViewModels.Users.UserDataRequest
{
    public class ChangePasswordUserRequest
    {
        [DisplayName("Current Password")]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }

        [DisplayName("New Password")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
