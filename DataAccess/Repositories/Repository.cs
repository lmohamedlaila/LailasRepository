using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace DataAccess.Repositories
{
    public class Repository : IRepository
    {
        private readonly DbContext _dbContext;
        private bool _disposed;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public T AttachAndUpdate<T>(T value) where T : class
        {
            _dbContext.Set<T>().Attach(value);
            _dbContext.Entry(value).State = EntityState.Modified;

            return value;
        }
        public void Delete<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Remove(entity);
        }
        public T Update<T>(T value) where T : class
        {
            _dbContext.Set<T>().AddOrUpdate(value);

            return value;
        }
        public T Add<T>(T value) where T : class
        {
            _dbContext.Set<T>().Add(value);

            return value;
        }
        public IList<T> Get<T>() where T : class
        {
            return _dbContext.Set<T>().ToList();
        }
        public void Save(bool skipLogging = false)
        {
            try
            {
                _dbContext.SaveChangesAsync();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }
            }
        }

        public DbContextTransaction BeginTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _dbContext.Dispose();
            }

            _disposed = true;
        }
    }
}
