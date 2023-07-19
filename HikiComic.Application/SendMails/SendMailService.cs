using HikiComic.Data.EF;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.SendMail;
using MailKit.Net.Smtp;
using static System.Net.WebRequestMethods;

namespace HikiComic.Application.SendMails
{
    public class SendMailService : ISendMailService
    {
        private readonly HikiComicDbContext _context;

        public SendMailService(HikiComicDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<bool>> SendMailOTP(string email, MailTypeEnum mailType, string otp, string fullName = "Sir or Madam", string htmlBonus = "")
        {
            if (mailType == MailTypeEnum.OTPEmailVerification)
            {
                var message = new EmailMessage()
                {
                    From = SystemConstants.AppSettings.EmailServer,
                    To = email,
                    MessageText = MessageConstants.MessageTextOTPMailVerification("Sir or Madam", otp),
                    Subject = MessageConstants.SubjectOTPMailVerification
                };

                try
                {
                    using (var client = new SmtpClient())
                    {
                        await client.ConnectAsync("smtp.gmail.com", 465, true);
                        await client.AuthenticateAsync(message.From, SystemConstants.AppSettings.EmailAuthenticate);
                        await client.SendAsync(message.GetMessage());
                        await client.DisconnectAsync(true);
                    }

                    return new ApiSuccessResult<bool>() { Message = MessageConstants.SendMailOTPVerificationSuccess };
                }
                catch (Exception ex)
                {
                    return new ApiErrorResult<bool>() { Message = ex.Message };
                }
            }
            else if (mailType == MailTypeEnum.OTPForgotPassword)
            {
                var message = new EmailMessage()
                {
                    From = SystemConstants.AppSettings.EmailServer,
                    To = email,
                    MessageText = MessageConstants.MessageTextOTPForgotPassword(fullName, otp),
                    Subject = MessageConstants.SubjectOTPForgotPassword
                };

                try
                {
                    using (var client = new SmtpClient())
                    {
                        await client.ConnectAsync("smtp.gmail.com", 465, true);
                        await client.AuthenticateAsync(message.From, SystemConstants.AppSettings.EmailAuthenticate);
                        await client.SendAsync(message.GetMessage());
                        await client.DisconnectAsync(true);
                    }

                    return new ApiSuccessResult<bool>() { Message = MessageConstants.SendMailOTPForgotPasswordSuccess };
                }
                catch (Exception ex)
                {
                    return new ApiErrorResult<bool>() { Message = ex.Message };
                }
            }
            else if(mailType == MailTypeEnum.EmailConfirmation)
            {
                var message = new EmailMessage()
                {
                    From = SystemConstants.AppSettings.EmailServer,
                    To = email,
                    MessageText = MessageConstants.MessageTextEmailConfirmations(fullName, otp),
                    Subject = MessageConstants.SubjectEmailConfirmations
                };

                try
                {
                    using (var client = new SmtpClient())
                    {
                        await client.ConnectAsync("smtp.gmail.com", 465, true);
                        await client.AuthenticateAsync(message.From, SystemConstants.AppSettings.EmailAuthenticate);
                        await client.SendAsync(message.GetMessage());
                        await client.DisconnectAsync(true);
                    }

                    return new ApiSuccessResult<bool>() { Message = MessageConstants.SendMailEmailConfirmationSuccess };
                }
                catch (Exception ex)
                {
                    return new ApiErrorResult<bool>() { Message = ex.Message };
                }
            }
            else if(mailType == MailTypeEnum.EmailCongratulations)
            {
                var message = new EmailMessage()
                {
                    From = SystemConstants.AppSettings.EmailServer,
                    To = email,
                    MessageText = MessageConstants.MessageTextEmailCongratulations(fullName, otp, htmlBonus),
                    Subject = MessageConstants.SubjectEmailCongratulations
                };

                try
                {
                    using (var client = new SmtpClient())
                    {
                        await client.ConnectAsync("smtp.gmail.com", 465, true);
                        await client.AuthenticateAsync(message.From, SystemConstants.AppSettings.EmailAuthenticate);
                        await client.SendAsync(message.GetMessage());
                        await client.DisconnectAsync(true);
                    }

                    return new ApiSuccessResult<bool>() { Message = MessageConstants.SendMailEmailCongratulationSuccess };
                }
                catch (Exception ex)
                {
                    return new ApiErrorResult<bool>() { Message = ex.Message };
                }
            }
            else
            {
                return new ApiErrorResult<bool>() { Message = "Don't implement" };
            }
        }

        public async Task<ApiResult<bool>> SendMailPaymentConfirmation(string email, string transactionId, string paymentMethod, string amount, string fullName = "Sir or Madam")
        {
            var message = new EmailMessage()
            {
                From = SystemConstants.AppSettings.EmailServer,
                To = email,
                MessageText = MessageConstants.MessageTextPaymentConfirmation("Sir or Madam", transactionId, paymentMethod, amount),
                Subject = MessageConstants.SubjectPaymentConfirmation(transactionId)
            };

            try
            {
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync("smtp.gmail.com", 465, true);
                    await client.AuthenticateAsync(message.From, SystemConstants.AppSettings.EmailAuthenticate);
                    await client.SendAsync(message.GetMessage());
                    await client.DisconnectAsync(true);
                }

                return new ApiSuccessResult<bool>() { Message = MessageConstants.SendMailEmailConfirmationSuccess };
            }
            catch (Exception ex)
            {
                return new ApiErrorResult<bool>() { Message = ex.Message };
            }
        }
    }
}
