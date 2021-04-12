namespace GithubInformationPresenter.Models
{
    public class GithubCommitDetails
    {
        public string Message { get; set; }

        public GithubCommitter Committer { get; set; }
    }
}
