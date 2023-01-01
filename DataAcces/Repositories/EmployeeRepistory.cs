using DataAcces.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Repositories
{
    public class EmployeeRepistory : IRepistory<Employee>
    {
        public bool Create(Employee entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Employee Get(Predicate<Employee> filters = null)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll(Predicate<Employee> filters = null)
        {
            throw new NotImplementedException();
        }

        public bool Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
