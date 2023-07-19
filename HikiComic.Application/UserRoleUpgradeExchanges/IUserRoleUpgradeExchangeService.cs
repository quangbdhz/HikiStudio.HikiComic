using HikiComic.Application.Base;
using HikiComic.Data.Entities;
using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserRoleUpgradeExchanges;
using HikiComic.ViewModels.UserRoleUpgradeExchanges.UserRoleUpgradeExchangeDataRequest;

namespace HikiComic.Application.UserRoleUpgradeExchanges
{
    public interface IUserRoleUpgradeExchangeService : IBaseService<UserRoleUpgradeExchange>
    {
        public Task<IList<UserRoleUpgradeExchangeViewModel>> GetUserRoleUpgradeExchangeByUserRoleUpgradeRequestId(int userRoleUpgradeRequestId);

        public Task<ApiResult<UserRoleUpgradeExchangeViewModel>> CreateUserRoleUpgradeExchange(CreateUserRoleUpgradeExchangeRequest request);
    }
}
