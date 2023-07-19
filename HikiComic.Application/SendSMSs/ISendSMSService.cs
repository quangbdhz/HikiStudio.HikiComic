using HikiComic.ViewModels.Common;
using Twilio.Rest.Api.V2010.Account;

namespace HikiComic.Application.SendSMSs
{
    public interface ISendSMSService
    {
        Task<ApiResult<MessageResource>> SendSMS(string message, string to);
    }
}
