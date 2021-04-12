using GithubInformationPresenter.DataAccess.Entities;
using GithubInformationPresenter.Models;
using System;

namespace GithubInformationPresenter.Mapping
{
    public static class GithubCommitMappings
    {
        public static Commit ToCommitEntity(this GithubCommit githubCommit, string username, string repository)
        {
            if (githubCommit == null)
            {
                throw new ArgumentNullException(nameof(githubCommit));
            }

            return new Commit
            {
                UserName = username,
                Repository = repository,
                Sha = githubCommit.Sha,
                Message = githubCommit.Commit?.Message,
                Committer = githubCommit.Commit?.Committer.ToCommitAuthor()
            };
        }

        private static Commit.CommitAuthor ToCommitAuthor(this GithubCommitter committer)
        {
            if (committer == null)
            {
                throw new ArgumentNullException(nameof(committer));
            }

            return new Commit.CommitAuthor
            {
                Name = committer.Name,
                Email = committer.Email,
                Date = committer.Date
            };
        }
    }
}
