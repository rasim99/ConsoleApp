using DataAcces.Interfaces;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Repositories
{
    public class DepartmentRepistory : IRepistory<Department>
    {
        public bool Create(Department entity)
        {
            try
            {
                AppDbContext.Departments.Add(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Department entity)
        {
            try
            {
                AppDbContext.Departments.Remove(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public Department Get(Predicate<Department> filters = null)
        {
            try
            {
                return filters != null ? AppDbContext.Departments.Find(filters) : AppDbContext.Departments[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Department> GetAll(Predicate<Department> filters = null)
        {
            try
            {
                //return filters == null ? AppDbContext.Departments : AppDbContext.Departments.FindAll(filters);
                return filters != null ? AppDbContext.Departments.FindAll(filters) : AppDbContext.Departments;
            }
            catch (Exception)
            {

                throw;
            }


        }

        public bool Update(Department entity)
        {
            try
            {
                Department exisDepartment = Get(dep => dep.Id == entity.Id);
                if (exisDepartment != null)
                {
                    exisDepartment = entity;
                    return true;
                }
                return false;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
