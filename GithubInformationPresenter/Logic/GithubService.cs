using GithubInformationPresenter.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace GithubInformationPresenter.Logic
{
    public interface IGithubService
    {
        Task<GithubResponse<CommitModel[]>> GetCommitsAsync(string owner, string repository);
    }

    public class GithubService : IGithubService
    {
        private readonly HttpClient _httpClient;

        public GithubService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GithubResponse<CommitModel[]>> GetCommitsAsync(string owner, string repository)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"/repos/{owner}/{repository}/commits");

            if (!response.IsSuccessStatusCode)
            {
                return GithubResponse<CommitModel[]>.Error($"Error occurred when getting data from github api: {response.ReasonPhrase}");
            }

            var json = await response.Content.ReadAsStringAsync();
            var mappedCommits = JsonConvert.DeserializeObject<CommitModel[]>(json);

            return GithubResponse<CommitModel[]>.Success(mappedCommits);
        }
    }
}
