using HikiComic.Data.Entities.Base.Entities;

namespace HikiComic.Data.Entities
{
    public class Gender : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int GenderId { get; set; }


        public string GenderName { get; set; } = null!;


        public List<AppUser> AppUsers { get; set; }
    }
}
