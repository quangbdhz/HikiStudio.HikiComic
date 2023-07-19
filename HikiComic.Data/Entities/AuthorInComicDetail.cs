namespace HikiComic.Data.Entities
{
    public class AuthorInComicDetail
    {
        public int AuthorId { get; set; }

        public int ComicDetailId { get; set; }

        public Author? Author { get; set; }

        public ComicDetail? ComicDetail { get; set; }

    }
}
