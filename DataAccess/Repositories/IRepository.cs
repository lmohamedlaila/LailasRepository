

using System.Collections.Generic;
using System.Data.Entity;

namespace DataAccess.Repositories
{
    public interface IRepository
    {
        T AttachAndUpdate<T>(T value) where T : class;
        T Update<T>(T value) where T : class;
        T Add<T>(T value) where T : class;
        IList<T> Get<T>() where T : class;
        void Save(bool skipLogging = false);
        DbContextTransaction BeginTransaction();
        void Delete<T>(T entity) where T : class;
    }
}
