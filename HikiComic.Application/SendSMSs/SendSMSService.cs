using HikiComic.Data.EF;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Settings;
using HikiComic.ViewModels.Common;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace HikiComic.Application.SendSMSs
{
    public class SendSMSService : ISendSMSService
    {

        private readonly HikiComicDbContext _context;

        private readonly SMSSetting _smsSetting;

        public SendSMSService(HikiComicDbContext context, IOptions<SMSSetting> smsSetting)
        {
            _context = context;
            _smsSetting = smsSetting.Value;
        }

        public async Task<ApiResult<MessageResource>> SendSMS(string message, string to)
        {
            TwilioClient.Init(_smsSetting.AccountSID, _smsSetting.AuthToken);

            try
            {
                var result = await MessageResource.CreateAsync(
                    body: "HikiComic - OTP: " + message + " - Expires within 15 minutes.",
                    from: new PhoneNumber(_smsSetting.PhoneNumber),
                    to: new PhoneNumber(to)
                );

                if (result.ErrorCode == null)
                    return new ApiSuccessResult<MessageResource>(result);
                else
                    return new ApiErrorResult<MessageResource>() { Message = MessageConstants.AnErrorOccureSendOTP };
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<MessageResource>() { Message = ex.Message};
            }


        }
    }
}
