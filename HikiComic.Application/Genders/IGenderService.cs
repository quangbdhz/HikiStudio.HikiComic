using HikiComic.Application.Base;
using HikiComic.Data.Entities;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.Genders;

namespace HikiComic.Application.Genders
{
    public interface IGenderService : IBaseService<Gender>
    {
        Task<ApiResult<IList<GenderViewModel>>> GetAll();
    }
}
