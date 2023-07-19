namespace HikiComic.ViewModels.Statistics
{
    public class StatisticalCreateComicByMonthViewModel
    {
        public ICollection<string> Labels { get; set; }

        public ICollection<int> Data { get; set; }

        public ICollection<string> ColorColumn { get; set; }

        public int ValueMaxColumn { get; set; }
    }
}
