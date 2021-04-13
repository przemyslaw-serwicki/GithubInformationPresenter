using GithubInformationPresenter.Models;

namespace GithubInformationPresenter.Logic.Write
{
    public interface IDataWriter
    {
        void WriteCommits(string owner, string repository, GithubCommit[] commits);
    }
}
