using Microsoft.AspNetCore.Identity;

namespace HikiComic.Data.Entities
{
    public class AppUserRole : IdentityUserRole<Guid>
    {
        public Guid AppUserRoleId { get; set; }

        public AppRole AppRole { get; set; }

        public AppUser AppUser { get; set; }
    }
}
