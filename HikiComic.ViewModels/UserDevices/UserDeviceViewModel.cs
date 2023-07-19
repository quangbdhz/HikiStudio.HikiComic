using HikiComic.ViewModels.Base;

namespace HikiComic.ViewModels.UserDevices
{
    public class UserDeviceViewModel : BaseViewModel<Guid>
    {
        public int AppUserDeviceId { get; set; }

        public Guid AppUserId { get; set; }

        public string DeviceId { get; set; } = null!;

        public string FCMDeviceToken { get; set; } = null!;

        public string DeviceType { get; set; } = null!;

        public string DeviceName { get; set; } = null!;

        public string DeviceOS { get; set; } = null!;
    }
}
