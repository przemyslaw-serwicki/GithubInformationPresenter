using GithubInformationPresenter.Models;
using System;

namespace GithubInformationPresenter.Logic
{
    public class ConsoleWriter : IDataWriter
    {
        public bool WriteCommits(string owner, string repository, CommitModel[] commits)
        {
            if (commits == null || commits.Length == 0)
            {
                Console.WriteLine($"No commits have been found in repository: {repository}, owned by: {owner}");
                return true;
            }

            Console.WriteLine("List of found commits:\n");
            foreach(var commitModel in commits)
            {
                SingleCommit singleCommit = commitModel.Commit;
                Console.WriteLine($"[{repository}]/[{commitModel.Sha}]: {singleCommit.Message} [{singleCommit.Committer}]\n");
            }

            return true;
        }
    }
}
