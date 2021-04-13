using GithubInformationPresenter.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace GithubInformationPresenter.Logic.Github
{
    public interface IGithubService
    {
        Task<GithubResponse<GithubCommit[]>> GetCommitsAsync(string owner, string repository);
    }

    public class GithubService : IGithubService
    {
        private readonly HttpClient _httpClient;

        public GithubService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GithubResponse<GithubCommit[]>> GetCommitsAsync(string owner, string repository)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"/repos/{owner}/{repository}/commits");

            if (!response.IsSuccessStatusCode)
            {
                return GithubResponse<GithubCommit[]>.Error($"Error occurred when getting data from github api: {response.ReasonPhrase}");
            }

            var json = await response.Content.ReadAsStringAsync();
            var mappedCommits = JsonConvert.DeserializeObject<GithubCommit[]>(json);

            return GithubResponse<GithubCommit[]>.Success(mappedCommits);
        }
    }
}
