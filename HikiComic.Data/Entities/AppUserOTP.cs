using HikiComic.Data.Entities.Base.Entities;
using HikiComic.Utilities.Enums;

namespace HikiComic.Data.Entities
{
    public class AppUserOTP : EntitySoftDeletableWithCreatedDate
    {
        public int AppUserOTPId { get; set; }

        public Guid AppUserId { get; set; }


        public OTPTypeEnum OTPType { get; set; }

        public string OTP { get; set; }

        public DateTime OTPExpires { get; set; }

        public bool IsOTPVerified { get; set; }
      

        public AppUser AppUser { get; set; }
    }
}
