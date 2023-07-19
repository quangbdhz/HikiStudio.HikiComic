namespace HikiComic.ViewModels.Accounts
{
    public class AccountViewModel
    {
        //user
        public Guid AppUserId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string Email { get; set; } = null!;

        public DateTime? DOB { get; set; }

        public string? PhoneNumber { get; set; }

        public string? UserImageURL { get; set; }

        public string? GenderName { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        //account
        public string? Nickname { get; set; }

        public double CoinsLeft { get; set; }

        public double CoinsSpent { get; set; }

        public double CoinsDeposited { get; set; }

        public double CoinsReceived { get; set; }

        public string? MoreInfo { get; set; }

        public double Experienced { get; set; }

        public DateTime DateModified { get; set; }

        //creator
        public bool IsSendRequestUpgradeCreator { get; set; }
    }
}
