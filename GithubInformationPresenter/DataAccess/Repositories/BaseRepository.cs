using LiteDB;
using System;
using System.Linq.Expressions;

namespace GithubInformationPresenter.DataAccess.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
    {
        private readonly ILiteDatabase _db;

        private bool _disposed;

        protected abstract string TableName { get; }

        protected ILiteCollection<T> Collection { get; }

        protected BaseRepository(ILiteDatabase database)
        {
            if (database == null)
            {
                throw new ArgumentNullException(nameof(database));
            }
            _db = database;
            Collection = _db.GetCollection<T>(TableName);
        }

        public virtual BsonValue Insert(T item)
        {
            return Collection.Insert(item);
        }

        public virtual bool Exists(Expression<Func<T, bool>> predicate)
        {
            return Collection.Exists(predicate);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~BaseRepository()
        {
            this.Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                if (_db != null)
                {
                    _db.Dispose();
                }
            }

            _disposed = true;
        }
    }
}
