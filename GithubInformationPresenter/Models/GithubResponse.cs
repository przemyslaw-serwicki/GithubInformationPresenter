namespace GithubInformationPresenter.Models
{
    public class GithubResponse<T>
    {
        public static GithubResponse<T> Success(T data) => new GithubResponse<T>(true, data: data);
        public static GithubResponse<T> Error(string errorMessage) => new GithubResponse<T>(false, errorMessage: errorMessage);

        public bool IsSuccess { get; }

        public string ErrorMessage { get; }

        public T Data { get; }

        public GithubResponse(bool isSuccess, string errorMessage = "", T data = default(T))
        {
            this.IsSuccess = isSuccess;
            this.ErrorMessage = errorMessage;
            this.Data = data;
        }
    }
}
