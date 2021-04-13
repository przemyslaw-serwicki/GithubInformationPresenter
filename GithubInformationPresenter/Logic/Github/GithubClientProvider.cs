using System;
using System.Net.Http;

namespace GithubInformationPresenter.Logic.Github
{
    public interface IHttpClientProvider
    {
        HttpClient GetClient();
    }

    public class GithubClientProvider : IHttpClientProvider
    {
        private const string GitHubApiPath = "https://api.github.com";

        public HttpClient GetClient()
        {
            var client = new HttpClient()
            {
                BaseAddress = new Uri(GitHubApiPath)
            };
            client.DefaultRequestHeaders.UserAgent.Add(
                new System.Net.Http.Headers.ProductInfoHeaderValue("GithubInformationPresenter", "1.0"));

            return client;
        }
    }
}
