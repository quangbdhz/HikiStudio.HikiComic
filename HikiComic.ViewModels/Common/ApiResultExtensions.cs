namespace HikiComic.ViewModels.Common
{
    public static class ApiResultExtensions
    {
        public static ApiResult<T> MapToResult<T>(this ApiResult<Guid> source)
        {
            return new ApiErrorResult<T>
            {
                IsSuccessed = source.IsSuccessed,
                Message = source.Message,
                StatusCode = source.StatusCode
            };
        }
    }
}
