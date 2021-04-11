using LiteDB;
using System;

namespace GithubInformationPresenter.DataAccess.Entities
{
    public class Commit
    {
        public ObjectId Id { get; set; }

        public string UserName { get; set; }

        public string Repository { get; set; }

        public string Sha { get; set; }

        public string Message { get; set; }

        public CommitAuthor Committer { get; set; }

        public class CommitAuthor
        {
            public string Name { get; set; }

            public string Email { get; set; }

            public DateTime Date { get; set; }
        }
    }
}
