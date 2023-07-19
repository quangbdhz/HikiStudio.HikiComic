using HikiComic.ViewModels.Common;

namespace HikiComic.Application.Base
{
    public interface IBaseService<T>
    {
        public Task<ApiResult<int>> CreateObject(object request);

        public Task<ApiResult<bool>> UpdateObject(int objectId, object request);

        public Task<ApiResult<bool>> DeleteObject(int objectId);

        public Task<ApiResult<bool>> DeleteObjects(IEnumerable<int> objectIds);

        public Task<ApiResult<bool>> RestoreDeletedObject(int objectId);
    }
}
