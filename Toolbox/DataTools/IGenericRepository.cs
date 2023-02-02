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

        Task CreateOneAsync(T entity);
        Task CreateManyAsync(IEnumerable<T> entities);

        T? ReadOneByKey(object entityKey);
        Task<T?> ReadOneByKeyAsync(object entityKey);

        //Koşul belirtilirse belitilen koşula uyan datanın ilk elemanı, yoksa ilgili tablonun ilk elemanı.
        T? ReadFirstOrDefault(Expression<Func<T, bool>>? expression = null);
        Task<T?> ReadFirstOrDefaultAsync(Expression<Func<T, bool>>? expression = null);

        //Koşul belirtilirse belitilen koşula uyan data, yoksa ilgili tablo.
        IEnumerable<T> ReadMany(Expression<Func<T, bool>>? expression = null);

        void UpdateOne(T entity);
        void UpdateMany(IEnumerable<T> entities);
        void DeleteOne(T entity);
        void DeleteOneByKey(object entityKey);
        void DeleteMany(IEnumerable<T> entities);

        //Saving
        void Save();
        Task SaveAsync();

        //Extras
        //Belirtilen koşula uyan data var mı?
        bool Exists(Expression<Func<T, bool>> expression);
        //Koşul belirtilirse belitilen koşula uyan datanın sayısı, yoksa ilgili tablonun eleman sayısı.
        int Count(Expression<Func<T, bool>>? expression = null);
    }
}
