using HikiComic.ViewModels.StatisticsReportForCreators;

namespace HikiComic.ViewModels.StatisticsReportForAdmins
{
    public class AdminCardViewModel : CreatorCardViewModel
    {
        public int CountAdmin { get; set; }

        public int CountTeamMeber { get; set; }

        public int CountReader { get; set; }

        public int CountRole { get; set; }

        public int CountConfig { get; set; }

        public int CountAuthor { get; set; }

        public int CountGenre { get; set; }

        public int CountArtist { get; set; }
    }
}
