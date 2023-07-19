using System.ComponentModel.DataAnnotations;

namespace HikiComic.ViewModels.Users.UserDataRequest
{
    public class UpdateUserRequest
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime DOB { get; set; }

        public int GenderId { get; set; }
    }
}
