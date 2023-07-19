namespace HikiComic.ViewModels.UserDevices.UserDeviceDataRequest
{
    public class CreateUserDeviceRequest
    {
        public string DeviceId { get; set; } = null!;

        public string FCMDeviceToken { get; set; } = null!;

        public string DeviceType { get; set; } = null!;

        public string DeviceName { get; set; } = null!;

        public string DeviceOS { get; set; } = null!;
    }
}
