using HikiComic.Data.EF;
using HikiComic.Utilities.Constants;
using HikiComic.Utilities.Enums;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserComicPurchases;
using Microsoft.EntityFrameworkCore;

namespace HikiComic.Application.UserComicPurchases
{
    public class UserComicPurchaseSerivice : IUserComicPurchaseService
    {
        private readonly HikiComicDbContext _context;

        public UserComicPurchaseSerivice(HikiComicDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResult<List<UserComicPurchaseViewModel>>> GetUserComicPurchases(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user is null)
                return new ApiErrorResult<List<UserComicPurchaseViewModel>>() { Message = MessageConstants.ObjectNotFound("User") };

            var account = await _context.Accounts.FirstOrDefaultAsync(x => x.AppUserId == user.Id);

            if (account is null)
                return new ApiErrorResult<List<UserComicPurchaseViewModel>>() { Message = MessageConstants.ObjectNotFound("Account") };

            var query = from c in _context.Comics
                        join cd in _context.ComicDetails on c.ComicId equals cd.ComicId
                        join ch in _context.Chapters on cd.ComicDetailId equals ch.ComicDetailId
                        join ucp in _context.UserComicPurchases on ch.ChapterId equals ucp.ChapterId
                        join ucuh in _context.UserCoinUsageHistories on ucp.UserCoinUsageHistoryId equals ucuh.UserCoinUsageHistoryId
                        where ucuh.AccountId == account.AccountId && ucp.ComicId == c.ComicId && ucp.ChapterId == ch.ChapterId 
                        && ucuh.UsageMethodId == UsageMethodEnum.ReadComics
                        select new { cd, c, ch, ucp, ucuh };

            //&& ch.ComicDetailId == cd.ComicDetailId && c.ComicId == cd.ComicId

            var userComicPurchases = await query.Select(x => new UserComicPurchaseViewModel()
            {
                UserCoinUsageHistoryId = x.ucuh.UserCoinUsageHistoryId,
                UserComicPurchaseId = x.ucp.UserComicPurchaseId,
                ComicId = x.c.ComicId,
                ComicSEOAlias = x.cd.ComicSEOAlias,
                ComicName = x.c.ComicName,
                ChapterId = x.ch.ChapterId,
                ChapterName = x.ch.ChapterName,
                ChapterSEOAlias = x.ch.ChapterSEOAlias,
                MoreInfo = x.ucp.MoreInfo,
                UsageAmount = x.ucuh.UsageAmount
            }).OrderByDescending(x => x.UserComicPurchaseId).ToListAsync();

            return new ApiSuccessResult<List<UserComicPurchaseViewModel>>() { ResultObj = userComicPurchases, Message = MessageConstants.GetObjectSuccess("UserComicPurchases") };
        }

    }
}
