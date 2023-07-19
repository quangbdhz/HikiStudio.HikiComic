namespace HikiComic.ViewModels.Common
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        public string[] ValidationErrors { get; set; } = null!;

        public ApiErrorResult()
        {
        }

        public ApiErrorResult(string message)
        {
            IsSuccessed = false;
            Message = message;
        }

        public ApiErrorResult(string[] validationErrors)
        {
            IsSuccessed = false;
            ValidationErrors = validationErrors;
        }
    }
}
