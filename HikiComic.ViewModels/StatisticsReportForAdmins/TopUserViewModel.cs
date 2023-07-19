namespace HikiComic.ViewModels.StatisticsReportForAdmins
{
    public class TopUserViewModel<T>
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string? Nickname { get; set; }

        public string? UserImageURL { get; set; }

        public T Value { get; set; }
    }
}
