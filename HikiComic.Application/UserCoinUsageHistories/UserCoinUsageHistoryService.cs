using EFCore.BulkExtensions;
using HikiComic.Data.EF;
using HikiComic.Data.Entities;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserCoinUsageHistories;
using HikiComic.ViewModels.UserCoinUsageHistories.UserCoinUsageHistoryDataRequest;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace HikiComic.Application.UserCoinUsageHistories
{
    public class UserCoinUsageHistoryService : IUserCoinUsageHistoryService
    {
        private readonly HikiComicDbContext _context;

        public UserCoinUsageHistoryService(HikiComicDbContext context)
        {
            _context = context;
        }

        public async Task<PagingResult<UserCoinUsageHistoryViewModel>> GetUserCoinUsageHistoriesPagingManagement(PagingRequest request, Guid userId)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AppUserId == userId);

            if (account is null)
                return new PagingResult<UserCoinUsageHistoryViewModel>();

            var userCoinUsageHistories = await _context.UserCoinUsageHistories.Where(x => x.AccountId == account.AccountId)
               .Select(x => new UserCoinUsageHistoryViewModel()
               {
                   UserCoinUsageHistoryId = x.UserCoinUsageHistoryId,
                   AccountId = account.AccountId,
                   UsageAmount = x.UsageAmount,
                   DateCreated = x.DateCreated,
                   UsageMethodName = ((UsageMethodEnum)x.UsageMethodId).ToString(),
                   UsageStatusName = ((UsageStatusEnum)x.UsageStatusId).ToString()
               }).OrderByDescending(x => x.DateCreated).ToListAsync();

            if (!string.IsNullOrEmpty(request.SortColumn) && !string.IsNullOrEmpty(request.SortColumnDirection))
            {
                userCoinUsageHistories = await _context.UserCoinUsageHistories.Where(x => x.AccountId == account.AccountId)
               .Select(x => new UserCoinUsageHistoryViewModel()
               {
                   UserCoinUsageHistoryId = x.UserCoinUsageHistoryId,
                   AccountId = account.AccountId,
                   UsageAmount = x.UsageAmount,
                   DateCreated = x.DateCreated,
                   UsageMethodName = ((UsageMethodEnum)x.UsageMethodId).ToString(),
                   UsageStatusName = ((UsageStatusEnum)x.UsageStatusId).ToString()
               }).OrderBy(request.SortColumn + " " + request.SortColumnDirection).ToListAsync();
            }

            if (!string.IsNullOrEmpty(request.SearchValue))
            {
                userCoinUsageHistories = userCoinUsageHistories.Where(x => x.UsageAmount.ToString().ToLower().Contains(request.SearchValue.ToLower()) || x.UsageStatusName.ToLower().Contains(request.SearchValue.ToLower())).ToList();
            }

            request.RecordsTotal = userCoinUsageHistories.Count();
            var data = userCoinUsageHistories.Skip(request.Skip).Take(request.PageSize).ToList();

            var jsonData = new { draw = request.Draw, recordsFiltered = request.RecordsTotal, recordsTotal = request.RecordsTotal, data = data };

            var result = new PagingResult<UserCoinUsageHistoryViewModel>()
            {
                Draw = request.Draw,
                RecordsFiltered = request.RecordsTotal,
                RecordsTotal = request.RecordsTotal,
                Data = data
            };

            return result;
        }

        public async Task<ApiResult<List<UserCoinUsageHistoryViewModel>>> GetUserCoinUsageHistories(Guid userId)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AppUserId == userId);

            if (account is null)
                return new ApiErrorResult<List<UserCoinUsageHistoryViewModel>>() { Message = MessageConstants.ObjectNotFound("Account") };

            var userCoinUsageHistories = await _context.UserCoinUsageHistories.Where(x => x.AccountId == account.AccountId && x.IsDeleted == false)
                .Select(x => new UserCoinUsageHistoryViewModel()
                {
                    UserCoinUsageHistoryId = x.UserCoinUsageHistoryId,
                    AccountId = account.AccountId,
                    UsageAmount = x.UsageAmount,
                    DateCreated = x.DateCreated,
                    UsageMethodName = ((UsageMethodEnum)x.UsageMethodId).ToString(),
                    UsageStatusName = ((UsageStatusEnum)x.UsageStatusId).ToString()
                }).OrderByDescending(x => x.DateCreated).ToListAsync();

            return new ApiSuccessResult<List<UserCoinUsageHistoryViewModel>>() { ResultObj = userCoinUsageHistories, Message = MessageConstants.GetObjectSuccess("UserCoinUsageHistories") };
        }

        public async Task<ApiResult<UserCoinUsageHistoryViewModel>> GetUserCoinUsageHistoryWithUserCoinUsageHistoryId(int userCoinUsageHistoryId)
        {
            var userCoinUsageHistory = await _context.UserCoinUsageHistories.FirstOrDefaultAsync(x => x.UserCoinUsageHistoryId == userCoinUsageHistoryId);

            if (userCoinUsageHistory is null)
                return new ApiErrorResult<UserCoinUsageHistoryViewModel>() { Message = MessageConstants.ObjectNotFound("UserCoinUsageHistory") };

            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountId == userCoinUsageHistory.AccountId);

            if (account is null)
                return new ApiErrorResult<UserCoinUsageHistoryViewModel>() { Message = MessageConstants.ObjectNotFound("Account") };

            var userCoinUsageHistoryViewModel = new UserCoinUsageHistoryViewModel()
            {
                UserCoinUsageHistoryId = userCoinUsageHistory.UserCoinUsageHistoryId,
                AccountId = userCoinUsageHistory.AccountId,
                AccountName = account.Nickname,
                UsageAmount = userCoinUsageHistory.UsageAmount,
                DateCreated = userCoinUsageHistory.DateCreated,
                UsageMethodName = ((UsageMethodEnum)userCoinUsageHistory.UsageMethodId).ToString(),
                UsageStatusName = ((UsageStatusEnum)userCoinUsageHistory.UsageStatusId).ToString()
            };

            return new ApiSuccessResult<UserCoinUsageHistoryViewModel>() { Message = MessageConstants.GetObjectSuccess("UserCoinUsageHistory"), ResultObj = userCoinUsageHistoryViewModel };
        }

        public async Task<ApiResult<bool>> CreateUserCoinUsageHistory(CreateUserCoinUsageHistoryRequest request, Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user is null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("User"));

            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AppUserId == user.Id);
            if (account is null)
                return new ApiErrorResult<bool>(MessageConstants.ObjectNotFound("Account"));

            var servicePrice = await _context.ServicePrices.FirstOrDefaultAsync(x => x.ServicePriceId == (int)request.UsageMethod);
            if (servicePrice is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ServiceDoesNotExist };

            var userCoinUsageHistory = new UserCoinUsageHistory()
            {
                AccountId = account.AccountId,
                UsageAmount = servicePrice.Price,
                UsageMethodId = request.UsageMethod,
                UsageStatusId = request.UsageStatus,
                DateCreated = DateTime.Now
            };

            if (userCoinUsageHistory.UsageStatusId == UsageStatusEnum.Completed)
            {
                if (request.UsageMethod == UsageMethodEnum.ReadComics && request.CreateUserComicPurchaseRequest != null)
                {
                    var comicDetail = await _context.ComicDetails.FirstOrDefaultAsync(x => x.ComicSEOAlias == request.CreateUserComicPurchaseRequest.ComicSEOAlias);
                    if (comicDetail is null)
                        return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound(nameof(Comic)) };

                    var chapter = await _context.Chapters.FirstOrDefaultAsync(x => x.ChapterSEOAlias == request.CreateUserComicPurchaseRequest.ChapterSEOAlias && x.ComicDetailId == comicDetail.ComicDetailId);
                    if (chapter is null)
                        return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound(nameof(Chapter)) };

                    var queryUserComicPurchase = from ucuh in _context.UserCoinUsageHistories
                                                 join ucp in _context.UserComicPurchases on ucuh.UserCoinUsageHistoryId equals ucp.UserCoinUsageHistoryId
                                                 join a in _context.Accounts on ucuh.AccountId equals a.AccountId
                                                 where a.AppUserId == userId && ucp.ChapterId == chapter.ChapterId && ucp.ComicId == comicDetail.ComicId
                                                 select new { ucp };

                    var checkUserComicPurchase = await queryUserComicPurchase.Select(x => new UserComicPurchase()
                    {
                        ComicId = x.ucp.ComicId,
                        ChapterId = x.ucp.ChapterId
                    }).ToListAsync();

                    if (checkUserComicPurchase.Count == 0)
                    {
                        if (0 > account.CoinsLeft - servicePrice.Price)
                        {
                            return new ApiResult<bool> { Message = MessageConstants.NotEnoughMoney };
                        }
                        else
                        {
                            account.CoinsLeft -= servicePrice.Price;
                            account.CoinsSpent += servicePrice.Price;
                            account.DateModified = DateTime.Now;

                            userCoinUsageHistory.UserComicPurchase = new UserComicPurchase()
                            {
                                UserCoinUsageHistoryId = userCoinUsageHistory.UserCoinUsageHistoryId,
                                ComicId = comicDetail.ComicId,
                                ChapterId = chapter.ChapterId,
                                MoreInfo = request.CreateUserComicPurchaseRequest.MoreInfo
                            };

                            await _context.UserCoinUsageHistories.AddAsync(userCoinUsageHistory);
                            await _context.SaveChangesAsync();

                            return new ApiSuccessResult<bool>() { Message = MessageConstants.BuyChapterComicSuccess };
                        }
                    }
                    else
                    {
                        return new ApiErrorResult<bool>() { Message = MessageConstants.BoughtThisChapterBefore };
                    }
                }
                else
                {
                    await _context.UserCoinUsageHistories.AddAsync(userCoinUsageHistory);

                    account.CoinsLeft -= servicePrice.Price;
                    account.CoinsSpent += servicePrice.Price;
                    account.DateModified = DateTime.Now;

                    await _context.SaveChangesAsync();

                    return new ApiSuccessResult<bool>() { Message = "Successfully" };
                }
            }

            return new ApiErrorResult<bool>() { Message = MessageConstants.AnErrorOccurred };
        }

        public async Task<ApiResult<bool>> DeleteUserCoinUsageHistory(int userCoinUsageHistoryId, Guid userId)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AppUserId == userId);

            if (account is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Account") };

            var userCoinUsageHistory = await _context.UserCoinUsageHistories.FirstOrDefaultAsync(x => x.UserCoinUsageHistoryId == userCoinUsageHistoryId);

            if (userCoinUsageHistory is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("UserCoinUsageHistory") };

            if (userCoinUsageHistory.AccountId != account.AccountId)
                return new ApiErrorResult<bool>() { Message = MessageConstants.AccessDenied };

            if (userCoinUsageHistory.IsDeleted)
                return new ApiSuccessResult<bool>() { Message = "The data you want to delete has already been deleted" };

            userCoinUsageHistory.IsDeleted = true;

            await _context.SaveChangesAsync();
            return new ApiSuccessResult<bool>() { Message = MessageConstants.DeleteSuccess("UserCoinUsageHistory") };
        }

        public async Task<ApiResult<bool>> DeleteAllUserCoinUsageHistories(Guid userId)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AppUserId == userId);

            if (account is null)
                return new ApiErrorResult<bool>() { Message = MessageConstants.ObjectNotFound("Account") };

            var bulkConfig = new BulkConfig { SetOutputIdentity = false };

            var userCoinUsageHistories = await _context.UserCoinUsageHistories.Where(x => !x.IsDeleted && x.AccountId == account.AccountId).ToListAsync();

            if (userCoinUsageHistories.Count == 0)
                return new ApiSuccessResult<bool>() { Message = MessageConstants.CoinUsageHistoryClean };

            foreach (var item in userCoinUsageHistories)
            {
                _context.Entry(item).Property(x => x.IsDeleted).CurrentValue = true;
                _context.Entry(item).State = EntityState.Modified;
            }

            await _context.BulkUpdateAsync(userCoinUsageHistories, bulkConfig);
            await _context.BulkSaveChangesAsync();

            return new ApiSuccessResult<bool>() { Message = MessageConstants.DeleteSuccess("UserCoinUsageHistories") };
        }
    }
}
