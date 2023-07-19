using HikiComic.Data.Entities.Base.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HikiComic.Data.Entities
{
    public class AppUser : IdentityUser<Guid>, IEntitySoftDelete, IEntityCreatedDate
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime? DOB { get; set; }

        public string? UserImageURL { get; set; }

        public int? GenderId { get; set; }


        public string RefreshToken { get; set; } = null!;

        public DateTime? TokenCreated { get; set; }

        public DateTime? TokenExpires { get; set; }


        public string? OTP { get; set; }

        public DateTime? OTPExpires { get; set; }

        public bool? IsOTPVerified { get; set; }


        public int AppUserTypeId { get; set; }

        public bool IsCreateAppUserWithThirdParty { get; set; }

        public bool IsPasswordChanged { get; set; }

        public DateTime? DatePasswordChanged { get; set; }

        public virtual bool IsDeleted { get; set; }

        public virtual DateTime DateCreated { get; set; }

        public Guid? CreatedBy { get; set; }


        public virtual Gender Gender { get; set; }

        public Account Account { get; set; }

        #region auth
        public List<AppUserRole> AppUserRoles { get; set; }

        public List<AppUserLogin> AppUserLogins { get; set; }

        public List<AppUserToken> AppUserTokens { get; set; }

        public List<AppUserClaim> AppUserClaims { get; set; }

        public List<AppUserOTP> AppUserOTPs { get; set; }
        #endregion

        #region using service
        public List<AppUserDevice> AppUserDevices { get; set; }

        public List<UserRoleUpgradeRequest> UserRoleUpgradeRequests { get; set; }

        public List<UserComicReadingHistory> UserComicReadingHistories { get; set; }

        public List<UserComicFollowing> UserComicFollowings { get; set; }

        public List<Comment> Comments { get; set; }

        public List<UserComicLike> UserComicLikes { get; set; }

        public List<UserComicRating> UserComicRatings { get; set; }

        public List<Notification> Notifications { get; set; }
        #endregion
    }
}
