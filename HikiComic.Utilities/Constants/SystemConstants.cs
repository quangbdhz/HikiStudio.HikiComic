namespace HikiComic.Utilities.Constants
{
    public class SystemConstants
    {
        public class AppSettings
        {
            public const string DomainMyHost = "hiki.space";

            public const string URLDomainMyHostProduct = "https://www.hiki.space/";

            public const string URLDomainMyHostDevelopment = "https://www.hiki.space/";

            public const string URLGooogleAPISUserInfo = "https://www.googleapis.com/oauth2/v3/userinfo?access_token=";

            public const string URLFacebookAPISUserInfo = "https://graph.facebook.com/me?access_token=";

            public const string MainConnectionString = "HikiComicDB";

            public const string Token = "Token";

            public const string BaseAddress = "BaseAddress";

            public const string EmailServer = "hikicomic.studio@gmail.com";

            public const string EmailAuthenticate = "ezeigihuecxsdgqq";

            public const string KeyExchangeRate = "ExchangeRate";

            public const string PathFolderUploadImageResponse = "uploads/user-avatar/";

            public const string UserImageURLDefault = "https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1689062558/HikiComic/AvatarOfUsers/default.jpg";

            public const string AvatarImageURLSystem = "https://res.cloudinary.com/https-deptraitd-blogspot-com/image/upload/v1689393059/HikiComic/AvatarOfUsers/svsvnqowg8yn3x3qgdlf.png";

            #region role
            public const string AdminRole = "admin";

            public const string TeamMembersRole = "teamMembers";

            public const string CreatorRole = "creator";

            public const string ReaderRole = "reader";
            #endregion

            #region policy
            public const string AdminPolicy = "AdminPolicy";

            public const string TeamMembersPolicy = "TeamMembersPolicy";

            public const string CreatorPolicy = "CreatorPolicy";

            public const string ReaderPolicy = "ReaderPolicy";

            public const string AdminOrTeamMembersPolicy = "AdminOrTeamMembersPolicy";

            public const string CRUDComicChapterPolicy = "CRUDComicChapterPolicy";
            #endregion
        }
    }
}
