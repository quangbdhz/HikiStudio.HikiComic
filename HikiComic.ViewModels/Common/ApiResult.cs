using HikiComic.Utilities.Enums;

namespace HikiComic.ViewModels.Common
{
    public class ApiResult<T>
    {
        public bool IsSuccessed { get; set; }

        public string Message { get; set; } = null!;

        public StatusCodeEnum StatusCode { get; set; }

        public T ResultObj { get; set; }
    }
}
