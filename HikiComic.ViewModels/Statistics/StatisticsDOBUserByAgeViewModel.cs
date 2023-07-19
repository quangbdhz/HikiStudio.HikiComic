namespace HikiComic.ViewModels.Statistics
{
    public class StatisticsDOBUserByAgeViewModel
    {
        public ICollection<string> Labels { get; set; }

        public ICollection<int> Data { get; set; }

        public ICollection<string> Colors { get; set; }
    }
}
