using HikiComic.Utilities.Enums;

namespace HikiComic.ViewModels.Chapters
{
    public class ChapterManagementViewModel : ChapterViewModel
    {
        public ApprovalStatusEnum ApprovalStatus { get; set; }

        public string StringApprovalStatus
        {
            get
            {
                return ApprovalStatus.ToString();
            }
        }

        public Guid? UserIdApproved { get; set; }

        public DateTime? DateApproved { get; set; }
    }
}
