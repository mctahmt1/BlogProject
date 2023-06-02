using BlogProject.Core.Entities;
using BlogProject.Data.Repositories.Abstracts;

namespace BlogProject.Data.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : class,IEntityBase,new();
        Task<int> SaveAsync();
        int Save();
    }
}
