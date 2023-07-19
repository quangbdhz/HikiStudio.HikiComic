using EFCore.BulkExtensions;
using HikiComic.Application.ExchangeRate;
using HikiComic.Application.SendMails;
using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.ExchangeRate;
using HikiComic.ViewModels.UserCoinDepositHistories;
using HikiComic.ViewModels.UserCoinDepositHistories.UserCoinDepositHistoryDataRequest;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace HikiComic.Application.UserCoinDepositHistories
{
    public class UserCoinDepositHistoryService : IUserCoinDepositHistoryService
    {
        private readonly HikiComicDbContext _context;

        private readonly IExchangeRateService _exchangeRateService;

        private readonly ISendMailService _sendMailService;

        public UserCoinDepositHistoryService(HikiComicDbContext context, IExchangeRateService exchangeRateService, ISendMailService sendMailService)
        {
            _context = context;
            _exchangeRateService = exchangeRateService;
            _sendMailService = sendMailService;
        }

        public async Task<PagingResult<UserCoinDepositHistoryViewModel>> GetUserCoinDepositHistoriesPagingManagement(PagingRequest request, Guid userId)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AppUserId == userId);

            if (account is null)
                return new PagingResult<UserCoinDepositHistoryViewModel>();

            var conversionRatioCoins = await _context.ServiceConfigs.FirstOrDefaultAsync(x => x.ServiceConfigId == (int)ServiceConfigEnum.ConversionRatioCoins);
            if (conversionRatioCoins is null)
                return new PagingResult<UserCoinDepositHistoryViewModel>();

            var userCoinDepositHistories = await _context.UserCoinDepositHistories.Where(x => x.AccountId == account.AccountId)
                .Select(x => new UserCoinDepositHistoryViewModel()
                {
                    UserCoinDepositHistoryId = x.UserCoinDepositHistoryId,
                    AccountId = x.AccountId,
                    TransactionId = x.TransactionId,
                    AccountName = account.Nickname,
                    OriginalCurrency = x.OriginalCurrency,
                    OriginalAmount = x.OriginalAmount,
                    ConvertCurrency = x.ConvertCurrency,
                    DepositAmount = x.DepositAmount,
                    Coins = (int)Math.Floor(x.DepositAmount / conversionRatioCoins.Value),
                    ExchangeRate = x.ExchangeRate,
                    DepositMethodId = x.DepositMethodId,
                    DepositStatusId = x.DepositStatusId,
                    DepositMethodName = (x.DepositMethodId).ToString(),
                    DepositStatusName = (x.DepositStatusId).ToString(),
                    DateCreated = x.DateCreated,
                    DepositCreateTime = x.DepositCreateTime,
                    DepositUpdateTime = x.DepositUpdateTime,
                    Remarks = x.Remarks
                }).OrderByDescending(x => x.UserCoinDepositHistoryId).ToListAsync();

            if (!string.IsNullOrEmpty(request.SortColumn) && !string.IsNullOrEmpty(request.SortColumnDirection))
            {
                userCoinDepositHistories = await _context.UserCoinDepositHistories.Where(x => x.AccountId == account.AccountId)
                .Select(x => new UserCoinDepositHistoryViewModel()
                {
                    UserCoinDepositHistoryId = x.UserCoinDepositHistoryId,
                    AccountId = x.AccountId,
                    TransactionId = x.TransactionId,
                    AccountName = account.Nickname,
                    OriginalCurrency = x.OriginalCurrency,
                    OriginalAmount = x.OriginalAmount,
                    ConvertCurrency = x.ConvertCurrency,
                    DepositAmount = x.DepositAmount,
                    Coins = (int)Math.Floor(x.DepositAmount / conversionRatioCoins.Value),
                    ExchangeRate = x.ExchangeRate,
                    DepositMethodId = x.DepositMethodId,
                    DepositStatusId = x.DepositStatusId,
                    DepositMethodName = (x.DepositMethodId).ToString(),
                    DepositStatusName = (x.DepositStatusId).ToString(),
                    DateCreated = x.DateCreated,
                    DepositCreateTime = x.DepositCreateTime,
                    DepositUpdateTime = x.DepositUpdateTime,
                    Remarks = x.Remarks
                }).OrderBy(request.SortColumn + " " + request.SortColumnDirection).ToListAsync();
            }

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                userCoinDepositHistories = userCoinDepositHistories.Where(x => x.TransactionId.ToLower().Contains(request.SearchValue.ToLower()) ||
                                                                               x.DepositAmount.ToString().ToLower().Contains(request.SearchValue.ToLower()) ||
                                                                               x.DepositStatusName.ToLower().Contains(request.SearchValue.ToLower())).ToList();
            }

            request.RecordsTotal = userCoinDepositHistories.Count();
            var data = userCoinDepositHistories.Skip(request.Skip).Take(request.PageSize).ToList();

            var jsonData = new { draw = request.Draw, recordsFiltered = request.RecordsTotal, recordsTotal = request.RecordsTotal, data = data };

            var result = new PagingResult<UserCoinDepositHistoryViewModel>()
            {
                Draw = request.Draw,
                RecordsFiltered = request.RecordsTotal,
                RecordsTotal = request.RecordsTotal,
                Data = data
            };

            return result;
        }

        public async Task<ApiResult<List<UserCoinDepositHistoryViewModel>>> GetUserCoinDepositHistories(Guid userId)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AppUserId == userId);
            if (account is null)
                return new ApiErrorResult<List<UserCoinDepositHistoryViewModel>>() { Message = MessageConstants.ObjectNotFound("Account") };

            var conversionRatioCoins = await _context.ServiceConfigs.FirstOrDefaultAsync(x => x.ServiceConfigId == (int)ServiceConfigEnum.ConversionRatioCoins);
            if (conversionRatioCoins is null)
                return new ApiErrorResult<List<UserCoinDepositHistoryViewModel>>() { Message = MessageConstants.AnErrorOccurred };

            var userCoinDepositHistories = await _context.UserCoinDepositHistories.Where(x => x.AccountId == account.AccountId && x.IsDeleted == false)
                .Select(x => new UserCoinDepositHistoryViewModel()
                {
                    UserCoinDepositHistoryId = x.UserCoinDepositHistoryId,
                    AccountId = x.AccountId,
                    TransactionId = x.TransactionId,
                    AccountName = account.Nickname,
                    OriginalCurrency = x.OriginalCurrency,
                    OriginalAmount = x.OriginalAmount,
                    ConvertCurrency = x.ConvertCurrency,
                    DepositAmount = x.DepositAmount,
                    Coins = (int)Math.Floor(x.DepositAmount / conversionRatioCoins.Value),
                    ExchangeRate = x.ExchangeRate,
                    DepositMethodId = x.DepositMethodId,
                    DepositStatusId = x.DepositStatusId,
                    DepositMethodName = (x.DepositMethodId).ToString(),
                    DepositStatusName = (x.DepositStatusId).ToString(),
                    DateCreated = x.DateCreated,
                    DepositCreateTime = x.DepositCreateTime,
                    DepositUpdateTime = x.DepositUpdateTime,
                    Remarks = x.Remarks
                }).OrderByDescending(x => x.DateCreated).ToListAsync();

            return new ApiSuccessResult<List<UserCoinDepositHistoryViewModel>>() { ResultObj = userCoinDepositHistories, Message = MessageConstants.GetObjectSuccess("UserCoinDepositHistories") };
        }

        public async Task<ApiResult<UserCoinDepositHistoryViewModel>> GetUserCoinDepositHistoryWithUserCoinDepositHistoryId(int userCoinDepositHistoryId)
        {
            var conversionRatioCoins = await _context.ServiceConfigs.FirstOrDefaultAsync(x => x.ServiceConfigId == (int)ServiceConfigEnum.ConversionRatioCoins);
            if (conversionRatioCoins is null)
                return new ApiErrorResult<UserCoinDepositHistoryViewModel>() { Message = MessageConstants.AnErrorOccurred };

            var userCoinDepositHistory = await _context.UserCoinDepositHistories.Where(x => x.UserCoinDepositHistoryId == userCoinDepositHistoryId).FirstOrDefaultAsync();

            if (userCoinDepositHistory is null)
                return new ApiErrorResult<UserCoinDepositHistoryViewModel>() { Message = MessageConstants.ObjectNotFound("UserCoinDepositHistory") };

            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountId == userCoinDepositHistory.AccountId);

            if (account is null)
                return new ApiErrorResult<UserCoinDepositHistoryViewModel>() { Message = MessageConstants.ObjectNotFound("Account") };

            var userCoinDepositHistoryViewModel = new UserCoinDepositHistoryViewModel()
            {
                UserCoinDepositHistoryId = userCoinDepositHistory.UserCoinDepositHistoryId,
                AccountId = userCoinDepositHistory.AccountId,
                TransactionId = userCoinDepositHistory.TransactionId,
                AccountName = account.Nickname,
                OriginalCurrency = userCoinDepositHistory.OriginalCurrency,
                OriginalAmount = userCoinDepositHistory.OriginalAmount,
                ConvertCurrency = userCoinDepositHistory.ConvertCurrency,
                DepositAmount = userCoinDepositHistory.DepositAmount,
                Coins = (int)Math.Floor(userCoinDepositHistory.DepositAmount / conversionRatioCoins.Value),
                ExchangeRate = userCoinDepositHistory.ExchangeRate,
                DepositMethodId = userCoinDepositHistory.DepositMethodId,
                DepositStatusId = userCoinDepositHistory.DepositStatusId,
                DepositMethodName = (userCoinDepositHistory.DepositMethodId).ToString(),
                DepositStatusName = (userCoinDepositHistory.DepositStatusId).ToString(),
                DateCreated = userCoinDepositHistory.DateCreated,
                DepositCreateTime = userCoinDepositHistory.DepositCreateTime,
                DepositUpdateTime = userCoinDepositHistory.DepositUpdateTime,
                Remarks = userCoinDepositHistory.Remarks
            };

            return new ApiSuccessResult<UserCoinDepositHistoryViewModel>() { Message = MessageConstants.GetObjectSuccess("UserCoinDepositHistory"), ResultObj = userCoinDepositHistoryViewModel };
        }

        public async Task<ApiResult<bool>> CheckAndChangeDepositStatus(ChangeDepositStatusRequest request)
        {
            var userCoinDepositHistory = await _context.UserCoinDepositHistories.FirstOrDefaultAsync(x => x.UserCoinDepositHistoryId == request.UserCoinDepositHistoryId);

            if (userCoinDepositHistory is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("UserCoinDepositHistory") };

            if (userCoinDepositHistory.DepositStatusId == DepositStatusEnum.Completed)
                return new ApiSuccessResult<bool>() { Message = MessageConstants.DepositStatusCompleted };

            if (userCoinDepositHistory.DepositStatusId == DepositStatusEnum.Failed)
                return new ApiSuccessResult<bool>() { Message = MessageConstants.DepositStatusFailed };

            if (request.DepositStatusId == (int)DepositStatusEnum.Completed)
            {
                var conversionRatioCoins = await _context.ServiceConfigs.FirstOrDefaultAsync(x => x.ServiceConfigId == (int)ServiceConfigEnum.ConversionRatioCoins);
                if (conversionRatioCoins is null)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.AnErrorOccurred };

                var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountId == userCoinDepositHistory.AccountId);

                if (account is null)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Account") };

                int coinDeposit = (int)Math.Floor(userCoinDepositHistory.DepositAmount / conversionRatioCoins.Value);

                account.CoinsLeft += coinDeposit;
                account.CoinsDeposited += coinDeposit;

                userCoinDepositHistory.DepositStatusId = DepositStatusEnum.Completed;

                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>() { Message = MessageConstants.DepositStatusPendingToCompleted };
            }
            else if (request.DepositStatusId == (int)DepositStatusEnum.Failed)
            {
                userCoinDepositHistory.DepositStatusId = DepositStatusEnum.Failed;

                await _context.SaveChangesAsync();

                return new ApiSuccessResult<bool>() { Message = MessageConstants.DepositStatusPendingToFailed };
            }
            else
            {
                return new ApiErrorResult<bool>() { Message = MessageConstants.AnErrorOccurred };
            }
        }
        
        public static Tuple<double, int> CalculateBonusCoins(double amount, double rate)
        {
            int bonusPercentage = 0;

            if (amount < 2*rate)
            {
                bonusPercentage = 0;
            }
            else if (amount >= 2 * rate && amount < 5 * rate)
            {
                bonusPercentage = 1;
            }
            else if (amount >= 5 * rate && amount < 10 * rate)
            {
                bonusPercentage = 2;
            }
            else if (amount >= 10 * rate && amount < 20 * rate)
            {
                bonusPercentage = 5;
            }
            else if (amount >= 20 * rate && amount < 50 * rate)
            {
                bonusPercentage = 10;
            }
            else if (amount >= 50 * rate && amount < 100 * rate)
            {
                bonusPercentage = 20;
            }
            else if (amount >= 100 * rate && amount < 1000 * rate)
            {
                bonusPercentage = 30;
            }
            else if (amount >= 1000 * rate && amount < 10000 * rate)
            {
                bonusPercentage = 50;
            }
            else if (amount >= 10000 * rate)
            {
                bonusPercentage = 100;
            }

            double bonusCoins = amount * bonusPercentage / 100;
            return new Tuple<double, int>(bonusCoins, bonusPercentage);
        }

        public async Task<ApiResult<bool>> CreateUserCoinDepositHistory(CreateUserCoinDepositHistoryRequest request, Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("User") };

            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AppUserId == user.Id);
            if (account is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Account") };

            var exchangeRateResult = await _exchangeRateService.ExchangeRate(new ExchangeRateRequest()
            {
                Amount = request.OriginalAmount,
                CurrencyCode = request.Currency,
                CurrencyCodeDefault = "VND"
            });

            if(!exchangeRateResult.IsSuccessed)
                return new ApiErrorResult<bool>() { Message = exchangeRateResult.Message };

            var userCoinDepositHistory = new UserCoinDepositHistory()
            {
                AccountId = account.AccountId,

                OriginalAmount = request.OriginalAmount,
                OriginalCurrency = request.Currency,
                DepositAmount = exchangeRateResult.ResultObj.AmountConverted,
                ConvertCurrency = "VND",
                ExchangeRate = $"({exchangeRateResult.ResultObj.ExchangeRateCurrency}:1:{exchangeRateResult.ResultObj.ExchangeRateCurrencyDefault})",
                TransactionId = request.TransactionId,

                DepositMethodId = request.DepositMethod,
                DepositStatusId = request.DepositStatus,

                DepositCreateTime = request.DepositCreateTime,
                DepositUpdateTime = request.DepositUpdateTime,
                Remarks = request.Remarks,
                DateCreated = DateTime.Now
            };

            await _context.UserCoinDepositHistories.AddAsync(userCoinDepositHistory);

            if (request.DepositStatus == DepositStatusEnum.Completed)
            {
                var conversionRatioCoins = await _context.ServiceConfigs.FirstOrDefaultAsync(x => x.ServiceConfigId == (int)ServiceConfigEnum.ConversionRatioCoins);
                if (conversionRatioCoins is null)
                    return new ApiErrorResult<bool>() { Message = MessageConstants.AnErrorOccurred };

                int coinDeposit = (int)Math.Floor(userCoinDepositHistory.DepositAmount / conversionRatioCoins.Value);

                account.CoinsLeft += coinDeposit;
                account.CoinsDeposited += coinDeposit;

                //additional coin bonus
                var resultRate = await _exchangeRateService.GetExchangeRateByCurrency("VND");
                if (!resultRate.IsSuccessed)
                    return new ApiSuccessResult<bool>() { Message = MessageConstants.DepositSuccess };

                var bonus = CalculateBonusCoins(userCoinDepositHistory.DepositAmount, resultRate.ResultObj);
                int coinBonus = (int)Math.Floor(bonus.Item1 / conversionRatioCoins.Value);

                userCoinDepositHistory.Remarks = $"Bonus {bonus.Item2}% = {coinBonus} " + userCoinDepositHistory.Remarks;
                account.CoinsLeft += coinBonus;
                account.CoinsDeposited += coinBonus;
                await _context.SaveChangesAsync();

                await _sendMailService.SendMailPaymentConfirmation(user.Email, request.TransactionId, request.DepositMethod.ToString(), request.OriginalAmount.ToString("N0").Replace(".", ",") + " " + request.Currency);

                return new ApiSuccessResult<bool>() { Message = MessageConstants.DepositSuccess };
            }
            else
            {
                await _context.SaveChangesAsync();

                if (request.DepositStatus == DepositStatusEnum.Pending)
                    return new ApiSuccessResult<bool>() { Message = MessageConstants.PendingDeposit };

                return new ApiSuccessResult<bool>() { Message = MessageConstants.DepositNotSuccess };
            }
        }

        public async Task<ApiResult<bool>> DeleteUserCoinDepositHistory(int userCoinDepositHistoryId, Guid userId)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AppUserId == userId);

            if (account is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Account") };

            var userCoinDepositHistory = await _context.UserCoinDepositHistories.FirstOrDefaultAsync(x => x.UserCoinDepositHistoryId == userCoinDepositHistoryId);

            if (userCoinDepositHistory is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("UserCoinDepositHistory") };

            if (userCoinDepositHistory.AccountId != account.AccountId)
                return new ApiErrorResult<bool>() { Message = MessageConstants.AccessDenied };

            if (userCoinDepositHistory.IsDeleted)
                return new ApiSuccessResult<bool>() { Message = "The data you want to delete has already been deleted" };

            userCoinDepositHistory.IsDeleted = true;

            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>() { Message = MessageConstants.DeleteSuccess("UserCoinDepositHistory") };
        }

        public async Task<ApiResult<bool>> DeleteAllUserCoinDepositHistories(Guid userId)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AppUserId == userId);

            if (account is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Account") };

            var bulkConfig = new BulkConfig { SetOutputIdentity = false };

            var userCoinDepositHistories = await _context.UserCoinDepositHistories.Where(x => x.IsDeleted == false && x.AccountId == account.AccountId).ToListAsync();

            if (userCoinDepositHistories.Count == 0)
                return new ApiSuccessResult<bool>() { Message = MessageConstants.CoinDepositHistoryClean };

            foreach (var item in userCoinDepositHistories)
            {
                _context.Entry(item).Property(x => !x.IsDeleted).CurrentValue = true;
                _context.Entry(item).State = EntityState.Modified;
            }

            await _context.BulkUpdateAsync(userCoinDepositHistories, bulkConfig);
            await _context.BulkSaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.DeleteSuccess("UserCoinDepositHistories") };
        }
    }
}
