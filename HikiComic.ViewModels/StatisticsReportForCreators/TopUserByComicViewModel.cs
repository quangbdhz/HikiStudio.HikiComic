using HikiComic.ViewModels.Common;

namespace HikiComic.ViewModels.StatisticsReportForCreators
{
    public class TopUserByComicViewModel<T> : StatisticsReportBase<T>
    {
        public List<T> UsageCoin { get; set; }

        public TopUserByComicViewModel()
        {
            Labels = new List<string>();
            Data = new List<T>();
            ColorColumn = new List<string>();
            UsageCoin = new List<T>();
        }
    }
}
