using HikiComic.Data.Entities.Base.Entities;
using HikiComic.Utilities.Enums;

namespace HikiComic.Data.Entities
{
    public class Genre : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int GenreId { get; set; }

        public int? GenreParentId { get; set; }


        public bool IsShowHome { get; set; }

        public string? GenreImageURL { get; set; }


        public ApprovalStatusEnum ApprovalStatus { get; set; }

        public Guid? UserIdApproved { get; set; }

        public DateTime? DateApproved { get; set; }


        public List<GenreInComicDetail> GenreInComicDetails { get; set; }

        public GenreDetail GenreDetail { get; set; }

        //public List<GenreDetail> GenreDetails { get; set; }
    }
}
