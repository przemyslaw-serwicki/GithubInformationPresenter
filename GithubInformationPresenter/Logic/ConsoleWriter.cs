using GithubInformationPresenter.Models;
using System;

namespace GithubInformationPresenter.Logic
{
    public class ConsoleWriter : IDataWriter
    {
        public void WriteCommits(string owner, string repository, GithubCommit[] commits)
        {
            if (commits == null || commits.Length == 0)
            {
                Console.WriteLine($"No commits have been found in repository: {repository}, owned by: {owner}");
                return;
            }

            Console.WriteLine("List of found commits:\n");
            foreach(var commit in commits)
            {
                GithubCommitDetails singleCommit = commit.Commit;
                Console.WriteLine($"[{repository}]/[{commit.Sha}]: {singleCommit.Message} [{singleCommit.Committer}]\n");
            }
        }
    }
}
