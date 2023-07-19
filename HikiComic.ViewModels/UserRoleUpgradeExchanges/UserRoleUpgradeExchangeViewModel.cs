using HikiComic.ViewModels.Base;

namespace HikiComic.ViewModels.UserRoleUpgradeExchanges
{
    public class UserRoleUpgradeExchangeViewModel : BaseViewModel<Guid>
    {
        public int UserRoleUpgradeExchangeId { get; set; }

        public int UserRoleUpgradeRequestId { get; set; }

        public string URLAvatar { get; set; }

        public string Message { get; set; }

        public bool IsReaded { get; set; }

        public bool IsReader { get; set; }
    }
}
