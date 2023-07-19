using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Base;

namespace HikiComic.ViewModels.UserRoleUpgradeRequests
{
    public class UserRoleUpgradeRequestViewModel : BaseViewModel<Guid>
    {
        public int UserRoleUpgradeRequestId { get; set; }

        public Guid AppUserId { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string? LastName { get; set; }

        public string? FirstName { get; set; }

        public string? PhoneNumber { get; set; }

        public ApprovalStatusEnum ApprovalStatus { get; set; }

        public string Status
        {
            get
            {
                return ApprovalStatus.ToString();
            }
        }
    }
}
