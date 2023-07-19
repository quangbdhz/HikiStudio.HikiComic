using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Common;

namespace HikiComic.Application.SendMails
{
    public interface ISendMailService
    {
        Task<ApiResult<bool>> SendMailOTP(string email, MailTypeEnum mailType, string otp, string fullName = "Sir or Madam", string htmlBonus = "");

        Task<ApiResult<bool>> SendMailPaymentConfirmation(string email, string transactionId, string paymentMethod, string amount, string fullName = "Sir or Madam");
    }
}
