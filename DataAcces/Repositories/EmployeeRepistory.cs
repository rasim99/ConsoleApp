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
            try
            {
                AppDbContext.Employees.Add(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(Employee entity)
        {
            try
            {
                AppDbContext.Employees.Remove(entity);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Employee Get(Predicate<Employee> filters = null)
        {
            try
            {
                return filters != null ? AppDbContext.Employees.Find(filters) : AppDbContext.Employees[0];
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Employee> GetAll(Predicate<Employee> filters = null)
        {
            try
            {
                return filters != null ? AppDbContext.Employees.FindAll(filters) : AppDbContext.Employees;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(Employee entity)
        {
            try
            {
                Employee exisEmlpoye = Get(empl => empl.Id == entity.Id);
                if (exisEmlpoye!=null)
                {
                    exisEmlpoye = entity;
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
