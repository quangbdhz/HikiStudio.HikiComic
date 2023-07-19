using HikiComic.ViewModels.Comics;

namespace HikiComic.ViewModels.Statistics
{
    public class StatisticsDashboardViewModel
    {
        public int NumberOfUsers { get; set; }

        public int NumberOfComics { get; set; }

        public int NumberOfChapters { get; set; }

        public int NumberOfAuthors { get; set; }

        public int NumberOfGenres { get; set; }

        public IList<ComicViewModel> Top5ComicMostViews { get; set; }

    }
}
