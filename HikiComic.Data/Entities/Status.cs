using HikiComic.Data.Entities.Base.Entities;

namespace HikiComic.Data.Entities
{
    public class Status : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int StatusId { get; set; }

        public string StatusName { get; set; } = null!;


        public List<ComicDetail> ComicDetails { get; set; }
    }
}
