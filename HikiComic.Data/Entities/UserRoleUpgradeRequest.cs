using HikiComic.Data.Entities.Base.Entities;
using HikiComic.Utilities.Enums;

namespace HikiComic.Data.Entities
{
    public class UserRoleUpgradeRequest : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int UserRoleUpgradeRequestId { get; set;}    

        public Guid AppUserId { get; set;}

        public Guid CurrentRoleId { get; set;}

        public Guid DesiredRoleId { get; set;}

        public ApprovalStatusEnum ApprovalStatus { get; set; }


        public AppUser AppUser { get; set;}

        public AppRole AppRole { get; set;}

        public List<UserRoleUpgradeExchange> UserRoleUpgradeExchanges { get; set;}
    }
}
