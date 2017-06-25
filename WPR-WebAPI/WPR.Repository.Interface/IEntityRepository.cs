using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPR.Repository.Interface
{
    public interface IEntityRepository<T, TType> 
    {
        IQueryable<T> GetAll();
        T Get(TType id, string userName);
        string Update(T entity);
        string Add(T entity);
        string AddRange(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
    }
}
