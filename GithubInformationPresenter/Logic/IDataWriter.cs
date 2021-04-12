using GithubInformationPresenter.Models;

namespace GithubInformationPresenter.Logic
{
    public interface IDataWriter
    {
        void WriteCommits(string owner, string repository, GithubCommit[] commits);
    }
}
