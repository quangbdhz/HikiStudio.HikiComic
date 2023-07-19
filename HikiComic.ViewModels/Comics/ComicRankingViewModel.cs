namespace HikiComic.ViewModels.Comics
{
    public class ComicRankingViewModel
    {
        public IList<ComicRankingCalculatorViewModel> HotComicsOfTheDay { get; set; }

        public IList<ComicRankingCalculatorViewModel> HotComicsOfTheWeek { get; set; }

        public IList<ComicRankingCalculatorViewModel> HotComicsOfTheMonth { get; set; }

        public IList<ComicRankingCalculatorViewModel> HotComicsOfTheYears { get; set; }

    }
}
