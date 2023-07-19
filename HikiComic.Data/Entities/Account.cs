using HikiComic.Data.Entities.Base.Entities;

namespace HikiComic.Data.Entities
{
    public class Account : EntitySoftDeletableWithCreatedDate
    {
        public int AccountId { get; set; }

        public Guid AppUserId { get; set; }


        public string? Nickname { get; set; }

        public double Experienced { get; set; }

        public string? MoreInfo { get; set; }


        public double CoinsLeft { get; set; }

        public double CoinsSpent { get; set; }

        public double CoinsDeposited { get; set; }

        public double CoinsReceived { get; set; }


        public DateTime DateModified { get; set; }


        public AppUser AppUser { get; set; }

        public List<UserCoinDepositHistory> UserCoinDepositHistories { get; set; }

        public List<UserCoinUsageHistory> UserCoinUsageHistories { get; set; }
    }
}
