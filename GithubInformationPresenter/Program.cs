using GithubInformationPresenter.Logic;
using GithubInformationPresenter.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GithubInformationPresenter
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Input arguments for owner and repository have not been provided");
                return 1;
            }

            //string owner = "przemyslaw-serwicki"; //will be as input
            //string repository = "GithubInformationPresenter"; //will be as input
            string owner = args[0];
            string repository = args[1];

            IHttpClientProvider httpClientProvider = new GithubClientProvider();
            HttpClient httpClient = httpClientProvider.GetClient();

            IGithubService githubService = new GithubService(httpClient);
            GithubResponse<GithubCommit[]> commitsResponse = await githubService.GetCommitsAsync(owner, repository);

            if (!commitsResponse.IsSuccess)
            {
                string errorMessage = string.IsNullOrEmpty(commitsResponse.ErrorMessage)
                    ? "Error occurred when calling github service"
                    : commitsResponse.ErrorMessage;
                Console.WriteLine(errorMessage);
            }
            else
            {
                IEnumerable<IDataWriter> dataWriters = new IDataWriter[] { new ConsoleWriter(), new DatabaseWriter() };
                foreach(var writer in dataWriters)
                {
                    writer.WriteCommits(owner, repository, commitsResponse.Data);
                }
            }

            Console.WriteLine("Program has finished its execution.");
            return 0;
        }
    }
}
