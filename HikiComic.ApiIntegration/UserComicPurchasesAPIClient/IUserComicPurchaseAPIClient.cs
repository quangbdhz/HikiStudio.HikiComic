using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserComicPurchases;

namespace HikiComic.ApiIntegration.UserComicPurchasesAPIClient
{
    public interface IUserComicPurchaseAPIClient
    {
        Task<ApiResult<List<UserComicPurchaseViewModel>>> GetUserComicPurchases(Guid userId);
    }
}
