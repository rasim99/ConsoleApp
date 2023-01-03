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
    public class DepartmentService : IDepartment
    {
        private readonly DepartmentRepistory departmentRepistory;
        public static int Id { get; set; }
        public DepartmentService()
        {
            departmentRepistory= new DepartmentRepistory();
        }
        public Department Create(Department department)
        {
            try
            {
                Department existDepartment = departmentRepistory.Get(dep => dep.Name.ToLower() == department.Name.ToLower());
                if (existDepartment==null)
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

                throw;
            }
            
        }

        public Department Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Department Delete(string name)
        {
            throw new NotImplementedException();
        }

        public Department Get(int id)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAll(int  capasity)
        {

            try
            {
                List<Department> departments =departmentRepistory.GetAll(dep=>dep.Capasity==capasity); 
                return departments;
            }
            catch (Exception)
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
            throw new NotImplementedException();
        }
    }
}
