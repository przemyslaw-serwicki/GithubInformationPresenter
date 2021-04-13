using GithubInformationPresenter.Models;
using LiteDB;
using System.Configuration;
using GithubInformationPresenter.Mapping;
using GithubInformationPresenter.DataAccess.Repositories;

namespace GithubInformationPresenter.Logic.Write
{
    public class DatabaseWriter : IDataWriter
    {
        public void WriteCommits(string owner, string repository, GithubCommit[] commits)
        {
            using ICommitsRepository commitsRepository = new CommitsRepository(GetLiteDatabase());
            foreach (var commit in commits)
            {
                var commitEntity = commit.ToCommitEntity(owner, repository);
                commitsRepository.InsertIfUnique(commitEntity);
            }
        }

        //TODO: If we decide to install IoC container like Autofac, we can setup resolve of LiteDatabase
        //Thanks to that, this method won't be neeeded here - CommitsRepository will know how to initialize and create LiteDatabase
        public ILiteDatabase GetLiteDatabase()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LiteDB"].ConnectionString;
            return new LiteDatabase(connectionString);
        }
    }
}
