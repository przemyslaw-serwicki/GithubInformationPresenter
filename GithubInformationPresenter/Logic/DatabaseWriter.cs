using GithubInformationPresenter.DataAccess.Entities;
using GithubInformationPresenter.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using GithubInformationPresenter.Mapping;

namespace GithubInformationPresenter.Logic
{
    public class DatabaseWriter : IDataWriter
    {
        public bool WriteCommits(string owner, string repository, CommitModel[] commits)
        {
            string conn = ConfigurationManager.ConnectionStrings["LiteDB"].ConnectionString;
            using (var db = new LiteDatabase(conn))
            {
                var col = db.GetCollection<Commit>("commits");
                col.EnsureIndex(x => x.Sha, true);

                foreach (var commit in commits)
                {
                    if (!col.Exists(x => x.Sha == commit.Sha))
                    {
                        var commitEntity = commit.ToCommitEntity(owner, repository);
                        col.Insert(commitEntity);
                    }
                }

                var inserted = col.FindAll().ToList();

                return true;
            }
        }
    }
}
