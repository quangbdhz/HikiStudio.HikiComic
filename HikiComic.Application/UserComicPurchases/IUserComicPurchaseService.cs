using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserComicPurchases;

namespace HikiComic.Application.UserComicPurchases
{
    public interface IUserComicPurchaseService
    {
        Task<ApiResult<List<UserComicPurchaseViewModel>>> GetUserComicPurchases(Guid userId);
    }
}
