using HikiComic.Utilities.Enums;

namespace HikiComic.ViewModels.Roles.RoleDataRequest
{
    public class CreateRoleRequest
    {
        public string RoleName { get; set; }

        public string? Description { get; set; }

        public RolePriorityEnum Priority { get; set; }
    }
}
