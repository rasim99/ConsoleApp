using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IDepartment
    {
        Department Create(Department department);
        Department Update(int id, Department department);
        Department Delete(int id);
        Department Get(int id);
        Department Delete(string name);
        List<Department> GetAll(int capasity);
        List<Department> GetAll();
    }
}
