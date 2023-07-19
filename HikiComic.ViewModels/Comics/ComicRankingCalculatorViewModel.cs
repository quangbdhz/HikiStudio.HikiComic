namespace HikiComic.ViewModels.Comics
{
    public class ComicRankingCalculatorViewModel : ComicViewModel
    {
        public double PointDay
        {
            get
            {
                return (ViewCount / (int)Math.Ceiling((DateTime.Now - DateCreated).TotalDays));
            }
        }

        public double PointWeek
        {
            get
            {
                int currentPoint = (int)Math.Ceiling((DateTime.Now - DateCreated).TotalDays) / 7;

                if (currentPoint != 0)
                {
                    return (ViewCount / currentPoint);
                }
                return ViewCount;
            }
        }

        public double PointMonth
        {
            get
            {
                int currentPoint = (int)Math.Ceiling((DateTime.Now - DateCreated).TotalDays) / 30;

                if (currentPoint != 0)
                {
                    return (ViewCount / currentPoint);
                }
                return ViewCount;
            }
        }

        public double PointYear
        {
            get
            {
                int currentPoint = (int)Math.Ceiling((DateTime.Now - DateCreated).TotalDays) / 365;

                if (currentPoint != 0)
                {
                    return (ViewCount / currentPoint);
                }
                return ViewCount;
            }
        }

    }
}
