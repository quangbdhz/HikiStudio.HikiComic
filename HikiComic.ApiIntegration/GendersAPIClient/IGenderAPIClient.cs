using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Genders;

namespace HikiComic.ApiIntegration.GendersAPIClient
{
    public interface IGenderAPIClient
    {
        Task<ApiResult<IList<GenderViewModel>>> GetAll();
    }
}
