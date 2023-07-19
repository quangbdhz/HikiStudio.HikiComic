using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Base;

namespace HikiComic.ViewModels.Roles
{
    public class RoleViewModel : BaseViewModel<Guid?>
    {
        public Guid RoleId { get; set; }

        public string RoleName { get; set; }

        public string? Description { get; set; }

        public RolePriorityEnum Priority { get; set; }

        public string PriorityName { get; set; }
    }
}
