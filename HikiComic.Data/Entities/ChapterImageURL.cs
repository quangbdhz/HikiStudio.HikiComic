using HikiComic.Data.Entities.Base.Entities;

namespace HikiComic.Data.Entities
{
    public class ChapterImageURL : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int ChapterImageURLId { get; set; }

        public int ChapterId { get; set; }


        public string ImageURL { get; set; } = null!;

        public int SerialImageURLOfChapter { get; set; }


        public Chapter? Chapter { get; set; }

    }
}
