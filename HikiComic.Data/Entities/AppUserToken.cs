using Microsoft.AspNetCore.Identity;

namespace HikiComic.Data.Entities
{
    public class AppUserToken : IdentityUserToken<Guid>
    {
        public int AppUserTokenId { get; set; }

        public AppUser AppUser { get; set; }
    }
}
