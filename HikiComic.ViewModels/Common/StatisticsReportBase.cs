using HikiComic.ViewModels.Comics;

namespace HikiComic.ViewModels.Common
{
    public class StatisticsReportBase<T>
    {
        public List<string> Labels { get; set; }

        public List<T> Data { get; set; }

        public List<string> ColorColumn { get; set; }

        public T ValueMaxColumn { get; set; }

        public List<InfoTopComicViewModel> TopComics { get; set; }

        public StatisticsReportBase()
        {
            Labels = new List<string>();
            Data = new List<T>();
            ColorColumn = new List<string>();
            TopComics = new List<InfoTopComicViewModel>();
        }
    }
}
