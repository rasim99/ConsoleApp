using Business.Interfaces;
using DataAcces.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class DepartmentServices : IDepartment
    {
        private readonly DepartmentRepistory departmentRepistory;
        public static  int Id { get; set; }
        public DepartmentServices()
        {
            departmentRepistory=new DepartmentRepistory();
        }
        public Department Create(Department department)
        {
            try
            {
                Department exisDepartment = departmentRepistory.Get(d => d.Name.ToLower() == department.Name.ToLower());
                if (exisDepartment==null)
                {
                    department.Id = Id;
                    if (departmentRepistory.Create(department))
                    {
                        Id++;
                        return department;
                    }
                }
                return null;

            }
            catch (Exception)
            {

                return null;
            }
        }

        public Department Delete(int id)
        {
            try
            {
                Department exisDepartment = departmentRepistory.Get(d => d.Id == id);
                if (exisDepartment!=null)
                {
                    departmentRepistory.Delete(exisDepartment);
                    return exisDepartment;
                }
                return null;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public Department Delete(string name)
        {
            try
            {
                Department exisDepartment = departmentRepistory.Get(d=>d.Name.ToLower()==name.ToLower());
                if (exisDepartment!=null)
                {
                    departmentRepistory.Delete(exisDepartment);
                    return exisDepartment;
                }
                return null;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public Department Get(int id)
        {
            Department exisDepartment = departmentRepistory.Get(d => d.Id == id);
            return exisDepartment;
        }

        public List<Department> GetAll(int capasity)
        {
            try
            {
                List<Department> exDepartment = departmentRepistory.GetAll(d => d.Capasity == capasity);
                if (exDepartment != null)
                {
                    return exDepartment;
                }
                return null;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public List<Department> GetAll()
        {
            try
            {
                return departmentRepistory.GetAll();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Department Update(int id, Department department)
        {
            try
            {
                Department exDepartment = departmentRepistory.Get(d => d.Id == id);
                if (exDepartment!=null)
                {
                    departmentRepistory.Update(exDepartment);
                    return exDepartment;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
