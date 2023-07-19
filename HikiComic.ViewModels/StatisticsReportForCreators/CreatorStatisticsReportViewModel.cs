using HikiComic.ViewModels.Common;

namespace HikiComic.ViewModels.StatisticsReportForCreators
{
    public class CreatorStatisticsReportViewModel
    {
        public CreatorCardViewModel Card { get; set; }

        public StatisticsReportBase<int> ComicMostFollowed { get; set; }

        public StatisticsReportBase<int> ComicMostViewed { get; set; }

        public TopUserByComicViewModel<double> TopUserBuyComics { get; set; }

        
    }
}
