using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;
using System.Diagnostics;
using HikiComic.ViewModels.Common;
using HikiComic.Utilities.Constants;

namespace HikiComic.Application.Common
{
    public class CommonService : ICommonService
    {
        private const string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        private const string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string NumericChars = "0123456789";
        private const string SpecialChars = "!@#$%^&*()_-+=<>?";

        private string ToSEOAlias(string value)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = value.Normalize(NormalizationForm.FormD);
            value = regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');

            Regex trimmer = new Regex(@"\s\s+");

            value = trimmer.Replace(value, " ");

            return value;
        }

        public string ConvertTitleToSEOAlias(string value, bool isSolidus = false, bool isChapter = false)
        {
            if (isChapter)
            {
                int index = value.IndexOf(":");
                if (index != -1)
                    value = value.Substring(0, index);
            }
            else
                value = value.Replace(":", "");

            value = value.Replace(".", "");
            value = value.Replace(",", "");
            value = value.Replace("'", "");
            value = value.Replace("’", "");

            //
            List<string> charSEOAlias = new List<string>();
            List<bool> specials = new List<bool>();

            foreach (var item in value)
            {
                charSEOAlias.Add(item.ToString());
                int code = (int)item;
                if ((code > 300 && code <= 7680) || code > 8200)
                    specials.Add(true);
                else
                    specials.Add(false);
            }

            Random rd = new Random();

            List<string> output = new List<string>();
            int length = charSEOAlias.Count;

            for (int i = 0; i < length; i++)
            {
                if (!specials[i])
                    output.Add(ToSEOAlias(charSEOAlias[i]));
                else
                    output.Add(charSEOAlias[i]);
            }

            value = String.Join("", output);

            if (!isSolidus)
                value = value.Replace(" ", "-") + "-" + rd.Next(100000, 999999);
            else
                value = "/" + value.Replace(" ", "-") + "-" + rd.Next(100000, 999999);

            return value.ToLower();
        }

        public string GenerateOTP(int length)
        {
            byte[] data = new byte[length];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(length);
            foreach (byte b in data)
            {
                result.Append((char)('0' + (b % 10)));
            }
            return result.ToString();
        }

        public void Measure(Action function, string message)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            function.Invoke();

            stopwatch.Stop();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message + " -|- Elapsed time: {0}", stopwatch.Elapsed);
            Console.ResetColor();
        }

        public string HashDataSHA256(string data)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(data));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool CheckFormatPhoneNumber(string phoneNumber)
        {
            string pattern = @"^\+\d{1,3}\d{9,12}$";

            Regex regex = new Regex(pattern);

            Match match = regex.Match(phoneNumber);

            return match.Success;
        }

        public ApiResult<string> GenerateToken(string userId, string secretKey, int expirationTimeInHours)
        {
            DateTime expirationTime = DateTime.UtcNow.AddHours(expirationTimeInHours);

            string dataToSign = userId + secretKey + expirationTime.ToString("yyyy-MM-dd HH:mm:ss");

            using (var rsa = new RSACryptoServiceProvider())
            {
                RSAParameters privateKey = rsa.ExportParameters(true);
                RSAParameters publicKey = rsa.ExportParameters(false);

                byte[] dataToSignBytes = Encoding.UTF8.GetBytes(dataToSign);

                byte[] signatureBytes = rsa.SignData(dataToSignBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                if (publicKey.Modulus != null && publicKey.Exponent != null)
                {

                    string token = Convert.ToBase64String(Encoding.UTF8.GetBytes(userId)) + "."
                        + Convert.ToBase64String(signatureBytes) + "."
                        + Convert.ToBase64String(Encoding.UTF8.GetBytes(expirationTime.ToString("yyyy-MM-dd HH:mm:ss"))) + "."
                        + Convert.ToBase64String(publicKey.Modulus) + "."
                        + Convert.ToBase64String(publicKey.Exponent);

                    return new ApiSuccessResult<string>() { ResultObj = token };
                }
                return new ApiErrorResult<string>() { ResultObj = "", Message = MessageConstants.AnErrorOccurredInFunction(nameof(GenerateToken), "") };
            }
        }

        public ApiResult<Guid> VerifyToken(string token, string secretKey)
        {
            try
            {
                string[] tokenParts = token.Split('.');

                if (tokenParts.Length != 5)
                    return new ApiErrorResult<Guid>() { Message = MessageConstants.UserEmailConfirmationInvalidToken };

                string tokenUserId = Encoding.UTF8.GetString(Convert.FromBase64String(tokenParts[0]));
                string tokenSignature = tokenParts[1];
                string tokenExpirationTime = Encoding.UTF8.GetString(Convert.FromBase64String(tokenParts[2]));
                byte[] tokenModulus = Convert.FromBase64String(tokenParts[3]);
                byte[] tokenExponent = Convert.FromBase64String(tokenParts[4]);

                DateTime expirationTime;
                if (!DateTime.TryParseExact(tokenExpirationTime, "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out expirationTime))
                    return new ApiErrorResult<Guid>() { Message = MessageConstants.UserEmailConfirmationInvalidToken };

                if (expirationTime <= DateTime.UtcNow)
                    return new ApiErrorResult<Guid>() { Message = MessageConstants.UserEmailConfirmationTokenExpired };

                string dataToVerify = tokenUserId + secretKey + expirationTime.ToString("yyyy-MM-dd HH:mm:ss");

                using (var rsa = new RSACryptoServiceProvider())
                {
                    RSAParameters publicKey = new RSAParameters();
                    publicKey.Modulus = tokenModulus;
                    publicKey.Exponent = tokenExponent;
                    rsa.ImportParameters(publicKey);

                    byte[] signatureBytes;
                    try
                    {
                        signatureBytes = Convert.FromBase64String(tokenSignature);
                    }
                    catch (FormatException)
                    {
                        return new ApiErrorResult<Guid>() { Message = MessageConstants.UserEmailConfirmationInvalidToken };
                    }

                    byte[] dataToVerifyBytes = Encoding.UTF8.GetBytes(dataToVerify);

                    bool isValid = rsa.VerifyData(dataToVerifyBytes, signatureBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                    if (!isValid)
                        return new ApiErrorResult<Guid>() { Message = MessageConstants.UserEmailConfirmationVerificationFailed };

                    if (Guid.TryParse(tokenUserId, out Guid userId))
                    {
                        return new ApiSuccessResult<Guid>() { Message = MessageConstants.UserEmailConfirmationVerificationSuccess, ResultObj = userId };
                    }
                    else
                    {
                        return new ApiErrorResult<Guid>() { Message = MessageConstants.AnErrorOccurred };
                    }
                }
            }
            catch (FormatException)
            {
                return new ApiErrorResult<Guid>() { Message = MessageConstants.UserEmailConfirmationInvalidToken };
            }
            catch (Exception)
            {
                return new ApiErrorResult<Guid>() { Message = "An error occurred during token verification." };
            }
        }

        public string GeneratePassword(int length, bool includeLowercase, bool includeUppercase, bool includeNumeric, bool includeSpecial)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Password length should be greater than zero.", nameof(length));
            }

            if (!includeLowercase && !includeUppercase && !includeNumeric && !includeSpecial)
            {
                throw new ArgumentException("At least one character set should be included in the password.",
                    nameof(includeLowercase) + ", " + nameof(includeUppercase) + ", " +
                    nameof(includeNumeric) + ", " + nameof(includeSpecial));
            }

            var validChars = string.Empty;

            if (includeLowercase)
            {
                validChars += LowercaseChars;
            }

            if (includeUppercase)
            {
                validChars += UppercaseChars;
            }

            if (includeNumeric)
            {
                validChars += NumericChars;
            }

            if (includeSpecial)
            {
                validChars += SpecialChars;
            }

            using (var rng = RandomNumberGenerator.Create())
            {
                var bytes = new byte[length];
                rng.GetBytes(bytes);

                var password = new char[length];
                for (var i = 0; i < length; i++)
                {
                    password[i] = validChars[bytes[i] % validChars.Length];
                }

                return new string(password);
            }
        }
    }
}
