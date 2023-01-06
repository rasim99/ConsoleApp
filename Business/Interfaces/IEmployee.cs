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
        Employee Create(Employee employee, string departmentName);
        Employee Update(int id, Employee employee, string departmentName);
        Employee Delete(int id);
        Employee Get(int id);
        List<Employee> GetAll(string name);
        List<Employee> Searchbydepartmen(string departmentName);
        List<Employee> GetAll();

    }
}
