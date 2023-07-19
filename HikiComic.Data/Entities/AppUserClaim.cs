using Microsoft.AspNetCore.Identity;

namespace HikiComic.Data.Entities
{
    public class AppUserClaim : IdentityUserClaim<Guid>
    {
        public AppUser AppUser { get; set; }
    }
}
