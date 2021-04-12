namespace GithubInformationPresenter.Models
{
    public class GithubCommit
    {
        public string Sha { get; set; }

        public GithubCommitDetails Commit { get; set; }
    }
}
