using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Toolbox.DataTools
{
    public interface IGenericRepository<T> where T : class
    {
        //CRUD
        void CreateOne(T entity);
        void CreateMany(IEnumerable<T> entities);
        T ReadOneByKey(object entityKey);

        //Koşul belirtilirse belitilen koşula uyan datanın ilk elemanı, yoksa ilgili tablonun ilk elemanı.
        T ReadFirstOrDefault(Expression<Func<T,bool>>? expression = null);

        //Koşul belirtilirse belitilen koşula uyan data, yoksa ilgili tablo.
        IEnumerable<T> ReadMany(Expression<Func<T, bool>>? expression = null);

        void UpdateOne(T entity);
        void UpdateMany(IEnumerable<T> entities);
        void DeleteOne(T entity);
        void DeleteOneByKey(object entityKey);
        void DeleteMany(IEnumerable<T> entities);

        //Saving
        void Save();

        //Extras
        //Belirtilen koşula uyan data var mı?
        bool Exists(Expression<Func<T, bool>> expression);
        //Koşul belirtilirse belitilen koşula uyan datanın sayısı, yoksa ilgili tablonun eleman sayısı.
        int Count(Expression<Func<T, bool>>? expression = null);
    }

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

        public int Count(Expression<Func<T, bool>>? expression = null)
        {
            throw new NotImplementedException();
        }

        public void CreateMany(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void CreateOne(T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteMany(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void DeleteOne(T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteOneByKey(object entityKey)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public T ReadFirstOrDefault(Expression<Func<T, bool>>? expression = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ReadMany(Expression<Func<T, bool>>? expression = null)
        {
            throw new NotImplementedException();
        }

        public T ReadOneByKey(object entityKey)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateMany(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void UpdateOne(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
