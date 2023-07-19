namespace HikiComic.Data.Entities
{
    public class GenreInComicDetail
    {
        public int GenreId { get; set; }

        public int ComicDetailId { get; set; }

        public Genre? Genre { get; set; }

        public ComicDetail? ComicDetail { get; set; }
    }
}
