using HikiComic.ViewModels.Common;
using HikiComic.ViewModels.UserRoleUpgradeExchanges;
using HikiComic.ViewModels.UserRoleUpgradeExchanges.UserRoleUpgradeExchangeDataRequest;

namespace HikiComic.ApiIntegration.UserRoleUpgradeExchangesAPIClient
{
    public interface IUserRoleUpgradeExchangeAPIClient
    {
        public Task<IList<UserRoleUpgradeExchangeViewModel>> GetUserRoleUpgradeExchangeByUserRoleUpgradeRequestId(int userRoleUpgradeRequestId);

        public Task<ApiResult<UserRoleUpgradeExchangeViewModel>> CreateUserRoleUpgradeExchange(CreateUserRoleUpgradeExchangeRequest request);

        public Task<ApiResult<bool>> DeleteUserRoleUpgradeExchange(int userRoleUpgradeExchangeId);

        public Task<ApiResult<bool>> DeleteUserRoleUpgradeExchanges(DeleteUserRoleUpgradeExchangesRequest request);

        public Task<ApiResult<bool>> RestoreDeletedUserRoleUpgradeExchange(int userRoleUpgradeExchangeId);
    }
}
