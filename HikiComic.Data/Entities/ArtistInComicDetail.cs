namespace HikiComic.Data.Entities
{
    public class ArtistInComicDetail
    {
        public int ArtistId { get; set; }

        public int ComicDetailId { get; set; }

        public Artist? Artist { get; set; }

        public ComicDetail? ComicDetail { get; set; }
    }
}
