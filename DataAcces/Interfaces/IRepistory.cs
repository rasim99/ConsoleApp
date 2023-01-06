using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Interfaces
{
    public interface IRepistory<T> where T : IEntity
    {
       bool Create (T entity);
        bool Update (T entity);
        bool Delete (T entity);
        T Get (Predicate   <T>filters=null);
       List < T> GetAll(Predicate<T>filters=null);
    }
}
