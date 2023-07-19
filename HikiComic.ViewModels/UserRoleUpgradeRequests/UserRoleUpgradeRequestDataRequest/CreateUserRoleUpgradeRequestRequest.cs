using HikiComic.Utilities.Enums;

namespace HikiComic.ViewModels.UserRoleUpgradeRequests.UserRoleUpgradeRequestDataRequest
{
    public class CreateUserRoleUpgradeRequestRequest
    {
        public int UserRoleUpgradeRequestId { get; set; }

        public ApprovalStatusEnum ApprovalStatus { get; set; }
    }
}
