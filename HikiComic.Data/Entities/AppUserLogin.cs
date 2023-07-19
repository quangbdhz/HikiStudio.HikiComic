using Microsoft.AspNetCore.Identity;

namespace HikiComic.Data.Entities
{
    public class AppUserLogin : IdentityUserLogin<Guid>
    {
        public int AppUserLoginId { get; set; }

        public AppUser AppUser { get; set; }
    }
}
