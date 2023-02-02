using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Toolbox.DataTools
{
    //abstract: Bir sınıfı soyut sınıf olarak tanımlar, bu sınıf new operatörü ile üretilemez sadece kalıtım alınarak kullanılabilir.
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected DbContext _context;
        protected DbSet<T> _set;

        protected GenericRepository(DbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public virtual int Count(Expression<Func<T, bool>>? expression = null)
        {
            return expression != null ? _set.Count(expression) : _set.Count();
        }

        public virtual void CreateMany(IEnumerable<T> entities)
        {
            _set.AddRange(entities);
        }

        public virtual async Task CreateManyAsync(IEnumerable<T> entities)
        {
            await _set.AddRangeAsync(entities);
        }

        public virtual void CreateOne(T entity)
        {
            _set.Add(entity);
        }

        public virtual async Task CreateOneAsync(T entity)
        {
            await _set.AddAsync(entity);
        }

        public virtual void DeleteMany(IEnumerable<T> entities)
        {
            _set.RemoveRange(entities);
        }

        public virtual void DeleteOne(T entity)
        {
            _set.Remove(entity);
        }

        public virtual void DeleteOneByKey(object entityKey)
        {
            T? entity = ReadOneByKey(entityKey);
            DeleteOne(entity);
        }

        public virtual bool Exists(Expression<Func<T, bool>> expression)
        {
            return _set.Any(expression);
        }

        public virtual T? ReadFirstOrDefault(Expression<Func<T, bool>>? expression = null)
        {
            return expression != null ? _set.FirstOrDefault(expression) : _set.FirstOrDefault();
        }

        public virtual async Task<T?> ReadFirstOrDefaultAsync(Expression<Func<T, bool>>? expression = null)
        {
            return expression != null ? await _set.FirstOrDefaultAsync(expression) : await _set.FirstOrDefaultAsync();
        }

        public virtual IEnumerable<T> ReadMany(Expression<Func<T, bool>>? expression = null)
        {
            return expression != null ? _set.Where(expression) : _set;
        }

        public virtual T? ReadOneByKey(object entityKey)
        {
            return _set.Find(entityKey);
        }

        public virtual async Task<T?> ReadOneByKeyAsync(object entityKey)
        {
            return await _set.FindAsync(entityKey);
        }

        //Yapılan değişikler veritabanına aktarılır, bu yapı geliştiriciye direk açık olmamalıdır, bu nokta için her proje her context için UnitOfWork yapoıs kullanmalı ve bu metodu oradagöstermelidir. Gerektiğinde rollback yapılabilir bir altyapı tercih edilmelidir.
        public virtual void Save()
        {
            _context.SaveChanges();
        }

        public virtual async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public virtual void UpdateMany(IEnumerable<T> entities)
        {
            _set.UpdateRange(entities);
        }

        public virtual void UpdateOne(T entity)
        {
            _set.Update(entity);
        }
    }
}
