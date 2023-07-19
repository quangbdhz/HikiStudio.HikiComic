using HikiComic.Utilities.Enums;
using Microsoft.AspNetCore.Identity;

namespace HikiComic.Data.Entities
{
    public class AppRole : IdentityRole<Guid>
    {
        public string? Description { get; set; }

        public RolePriorityEnum Priority { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DateCreated { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime? DateUpdated { get; set; }

        public Guid? UpdatedBy { get; set; }

        public List<AppUserRole> AppUserRoles { get; set; }

        public List<AppRoleClaim> AppRoleClaims { get; set; }

        public List<UserRoleUpgradeRequest> UserRoleUpgradeRequests { get; set; }
    }
}
