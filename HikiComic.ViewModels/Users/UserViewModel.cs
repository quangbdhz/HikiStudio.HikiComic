using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Roles;
using System.ComponentModel.DataAnnotations;

namespace HikiComic.ViewModels.Users
{
    public class UserViewModel
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool EmailConfirmed { get; set; }

        [Display(Name = "DOB")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }

        public string? GenderName { get; set; }

        public bool IsDeleted { get; set; }

        public string? UserImageURL { get; set; }

        public bool LockoutEnabled { get; set; }

        public IList<string> StringRoles { get; set; }

        public IList<RoleViewModel>? Roles { get; set; }

        public bool IsDisable
        {
            get
            {
                if (Roles != null)
                {
                    if (Roles.Any(r => r.Priority == RolePriorityEnum.Medium || r.Priority == RolePriorityEnum.High))
                    {
                        return true;
                    }
                }

                return false;
            }
        }
    }
}
