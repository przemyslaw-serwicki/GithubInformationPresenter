using GithubInformationPresenter.DataAccess.Entities;
using GithubInformationPresenter.Models;
using System;

namespace GithubInformationPresenter.Mapping
{
    public static class CommitModelMappings
    {
        public static Commit ToCommitEntity(this CommitModel commitModel, string username, string repository)
        {
            if (commitModel == null)
            {
                throw new ArgumentNullException(nameof(commitModel));
            }

            return new Commit
            {
                UserName = username,
                Repository = repository,
                Sha = commitModel.Sha,
                Message = commitModel.Commit?.Message,
                Committer = commitModel.Commit?.Committer.ToCommitAuthor()
            };
        }

        private static Commit.CommitAuthor ToCommitAuthor(this Committer committer)
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
