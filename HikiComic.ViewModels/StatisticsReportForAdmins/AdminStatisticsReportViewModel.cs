namespace HikiComic.ViewModels.StatisticsReportForAdmins
{
    public class AdminStatisticsReportViewModel
    {
        public AdminCardViewModel Card { get; set; }


        public List<TopUserCoinViewModel<double>> TopReaderDepositCoinByDay { get; set; }

        public List<TopUserCoinViewModel<double>> TopReaderDepositCoinByMonth { get; set; }

        public List<TopUserCoinViewModel<double>> TopReaderDepositCoinByYear { get; set; }


        public List<TopUserCoinViewModel<double>> TopReaderUsageCoinByDay { get; set; }

        public List<TopUserCoinViewModel<double>> TopReaderUsageCoinByMonth { get; set; }

        public List<TopUserCoinViewModel<double>> TopReaderUsageCoinByYear { get; set; }


        public List<TopUserViewModel<double>> TopCreatorComicMostViewed { get; set; }

        public List<TopUserViewModel<double>> TopCreatorComicMostCoinByDay { get; set; }

        public List<TopUserViewModel<double>> TopCreatorComicMostCoinByMonth { get; set; }

        public List<TopUserViewModel<double>> TopCreatorComicMostCoinByYear { get; set; }

    }
}
