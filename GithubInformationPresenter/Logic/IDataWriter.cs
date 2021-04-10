using GithubInformationPresenter.Models;

namespace GithubInformationPresenter.Logic
{
    public interface IDataWriter
    {
        bool WriteCommits(string owner, string repository, CommitModel[] commits);
    }
}
