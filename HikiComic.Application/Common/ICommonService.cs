using HikiComic.ViewModels.Common;

namespace HikiComic.Application.Common
{
    public interface ICommonService
    {
        public string ConvertTitleToSEOAlias(string value, bool isSolidus = false, bool isChapter = false);

        public string GenerateOTP(int length);

        public string GeneratePassword(int length, bool includeLowercase, bool includeUppercase, bool includeNumeric, bool includeSpecial);

        public void Measure(Action function, string message);

        public string HashDataSHA256(string data);

        public bool CheckFormatPhoneNumber(string phoneNumber);

        public ApiResult<string> GenerateToken(string userId, string secretKey, int expirationTimeInHours);

        public ApiResult<Guid> VerifyToken(string token, string secretKey);
    }
}
