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
    public class EmployeeService : IEmployee
    {

        private readonly EmployeeRepistory employeeRepistory;
        private readonly DepartmentServices departmentServices;
        public static int Id { get; set; }

        public EmployeeService()
        {
            employeeRepistory = new EmployeeRepistory();
            departmentServices = new DepartmentServices();
        }

        public Employee Create(Employee employee,string departmentName)
        {
            Department department = departmentServices.Get(departmentName);
            try
            {
                if (department != null)
                {
                    employee.department = department;
                    employee.Id = Id;
                    if (employeeRepistory.Create(employee))
                    {
                        Id++;
                        return employee;
                    }
                }
                return null;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public Employee Update(int id, Employee employee, string departmentName)
        {
            try
            {
                Employee exsEmployee = employeeRepistory.Get(e => e.Id == id);

                if (exsEmployee!=null)
                {
                    Department department = departmentServices.Get(departmentName);
                   
                     if (department!=null)
                    {
                        exsEmployee.department = department;
                        exsEmployee.Name = employee.Name??exsEmployee.Name;
                        exsEmployee.Surname = employee.Surname;
                        exsEmployee.Age = employee.Age;
                        exsEmployee.Adress = employee.Adress;


                        employeeRepistory.Update(employee);
                        return exsEmployee;
                    }
                     else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch(Exception)
            {
                return null;
            }
        }

        public Employee Delete(int id)
        {
            try
            {
                Employee exisEmployee = employeeRepistory.Get(d => d.Id == id);
                if (exisEmployee != null)
                {
                    employeeRepistory.Delete(exisEmployee);
                    return exisEmployee;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Employee Get(int id)
        {
            Employee exisEmploye = employeeRepistory.Get(d => d.Id == id);
            return exisEmploye;
        }

        public List<Employee> GetAll(string name)
        {
            List<Employee> exsemp = employeeRepistory.GetAll(exp => exp.Name.ToLower() == name.ToLower());
            if (exsemp!=null)
            {
                return exsemp;
            }
            return null;
        }

        public List<Employee> Searchbydepartmen(string departmentName)
        {
            List<Employee> exEmploy = employeeRepistory.GetAll(e => e.department.Name.ToLower() == departmentName.ToLower());
            if (exEmploy!=null)
            {
                return exEmploy;
            }
            return null;
        }

        public List<Employee> GetAll()
        {
            try
            {
                return employeeRepistory.GetAll();
            }
            catch (Exception)
            {
                return null;
            }
        }

      
    }
}  
