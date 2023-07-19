using HikiComic.Data.Entities.Base.Entities;

namespace HikiComic.Data.Entities
{
    public class UserRoleUpgradeExchange : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int UserRoleUpgradeExchangeId { get; set; }

        public int UserRoleUpgradeRequestId { get; set; }

        public string Message { get; set; }

        public bool IsReaded { get; set; }

        public bool IsReader { get; set; }

        public UserRoleUpgradeRequest UserRoleUpgradeRequest { get; set; }
    }
}
