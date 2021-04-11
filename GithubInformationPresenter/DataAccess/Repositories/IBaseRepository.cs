using LiteDB;
using System;
using System.Linq.Expressions;

namespace GithubInformationPresenter.DataAccess.Repositories
{
    public interface IBaseRepository<T> : IDisposable
    {
        bool Exists(Expression<Func<T, bool>> predicate);

        BsonValue Insert(T item);
    }
}
