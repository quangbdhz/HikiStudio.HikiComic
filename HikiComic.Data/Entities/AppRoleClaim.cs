using Microsoft.AspNetCore.Identity;

namespace HikiComic.Data.Entities
{
    public class AppRoleClaim : IdentityRoleClaim<Guid>
    {
        public AppRole AppRole { get; set; }
    }
}
