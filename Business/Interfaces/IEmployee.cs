using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IEmployee
    {
        Employee Create(Employee employee);
         Employee Update(int id ,Employee employee);
        Employee Delete(int id);
        Employee Get(int id);
        List<Employee> GetAll(string name);
        List<Employee> GetAll();
        
    }
}
