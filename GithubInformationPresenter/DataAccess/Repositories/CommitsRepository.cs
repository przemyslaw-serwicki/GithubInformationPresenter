using GithubInformationPresenter.DataAccess.Entities;
using LiteDB;

namespace GithubInformationPresenter.DataAccess.Repositories
{
    public interface ICommitsRepository : IBaseRepository<Commit>
    {
        ObjectId InsertIfUnique(Commit commit);
    }

    public class CommitsRepository : BaseRepository<Commit>, ICommitsRepository
    {
        public CommitsRepository(ILiteDatabase database) : base(database)
        {
            Collection.EnsureIndex(x => x.Sha);
        }

        protected override string TableName => "commits";

        public ObjectId InsertIfUnique(Commit commit)
        {
            if (this.Exists(x => x.Sha == commit.Sha))
            {
                return null;
            }

            return this.Insert(commit);
        }
    }
}
