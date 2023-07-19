using HikiComic.Data.Entities.Base.Entities;

namespace HikiComic.Data.Entities
{
    public class AppUserDevice : EntitySoftDeleteWithTimestamps<Guid?>
    {
        public int AppUserDeviceId { get; set; }

        public Guid AppUserId { get; set; }


        public string DeviceId { get; set; } = null!;

        public string FCMDeviceToken { get; set; } = null!;

        public string DeviceType { get; set; } = null!;

        public string DeviceName { get; set; } = null!;

        public string DeviceOS { get; set; } = null!;


        public AppUser AppUser { get; set; }
    }
}
