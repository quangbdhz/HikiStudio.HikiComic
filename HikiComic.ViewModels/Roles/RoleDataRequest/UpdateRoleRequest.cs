using HikiComic.Utilities.Enums;

namespace HikiComic.ViewModels.Roles.RoleDataRequest
{
    public class UpdateRoleRequest
    {
        public string RoleName { get; set; }

        public string? Description { get; set; }

        public RolePriorityEnum Priority { get; set; }
    }
}
