using RestApiModeloDDD.Domain.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace RestApiModeloDDD.Infrastructure.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly SqlContext _sqlContext;

        public RepositoryBase(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public void Add(TEntity obj)
        {
            _sqlContext.Add(obj);
            _sqlContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _sqlContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _sqlContext.Set<TEntity>().Find(id);
        }

        public void Remove(TEntity obj)
        {
            _sqlContext.Set<TEntity>().Remove(obj);
            _sqlContext.SaveChanges();
        }

        public void Update(TEntity obj)
        {
            _sqlContext.Set<TEntity>().Update(obj);
            _sqlContext.SaveChanges();
        }
    }
}