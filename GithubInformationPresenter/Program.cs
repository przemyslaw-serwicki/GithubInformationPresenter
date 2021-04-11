using GithubInformationPresenter.Logic;
using GithubInformationPresenter.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GithubInformationPresenter
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string owner = "przemyslaw-serwicki"; //will be as input
            string repository = "GithubInformationPresenter"; //will be as input

            IHttpClientProvider httpClientProvider = new GithubClientProvider();
            HttpClient httpClient = httpClientProvider.GetClient();

            IGithubService githubService = new GithubService(httpClient);
            GithubResponse<CommitModel[]> commitsResponse = await githubService.GetCommitsAsync(owner, repository);

            if (!commitsResponse.IsSuccess)
            {
                string errorMessage = string.IsNullOrEmpty(commitsResponse.ErrorMessage)
                    ? "Error occurred when calling github service"
                    : commitsResponse.ErrorMessage;
                Console.WriteLine(errorMessage);
            }
            else
            {
                //use collection of IDataWriter[]
                IDataWriter writer = new ConsoleWriter();
                writer.WriteCommits(owner, repository, commitsResponse.Data);

                var sqlWriter = new DatabaseWriter();
                sqlWriter.WriteCommits(owner, repository, commitsResponse.Data);
            }
        }
    }
}
