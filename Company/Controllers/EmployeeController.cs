using Business.Interfaces;
using Business.Services;
using DataAcces.Repositories;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Helpers;

namespace ACompany.Controllers
{

    public class EmployeeController
    {
        private readonly DepartmentRepistory departmentRepistory;
        private readonly EmployeeService employeeService;
        private readonly DepartmentServices departmentService;
        public EmployeeController()
        {
            departmentRepistory = new DepartmentRepistory();
            employeeService = new EmployeeService();
            departmentService = new DepartmentServices();

        }
    public void CreateEmployee()
        {

            exEmple: Helper.HelperMessage(ConsoleColor.White, "Please  enter Employee's name!");

            string EmployeeName = Console.ReadLine();
            Helper.HelperMessage(ConsoleColor.White, "Please  enter Employee's Surname!");
            string EmployeeSurname = Console.ReadLine();
         Helper.HelperMessage(ConsoleColor.Blue, "Please  enter Age");
            int Age = int.Parse(Console.ReadLine());
            Helper.HelperMessage(ConsoleColor.Blue, "Please  Department Name");
            string departmentName = Console.ReadLine();
            Helper.HelperMessage(ConsoleColor.White, "Please  enter Employee's  Adress");
            string Adress = Console.ReadLine();
            Employee employee = new();
            employee.Name = EmployeeName;
            employee.Surname = EmployeeSurname;
            employee.Adress = Adress;
            employee.Age = Age;
            Employee newEmplo=employeeService.Create(employee, departmentName);

            if (newEmplo!=null)
            {
                Helper.HelperMessage(ConsoleColor.DarkCyan, $"{newEmplo.Name} created");
            }
            else
            {
                Helper.HelperMessage(ConsoleColor.Red, $"Dont Create the Employe");
                goto exEmple;
            }
        }
        public void UpdateEmployee()
        {
            Helper.HelperMessage(ConsoleColor.DarkCyan, " Enter Employee's ID");
            int ID = int.Parse(Console.ReadLine());

            Helper.HelperMessage(ConsoleColor.DarkCyan, " Enter Employee's Adress");
            string adres = Console.ReadLine();

            Helper.HelperMessage(ConsoleColor.DarkCyan, " Enter Employee's Department Name");
            string deprName = Console.ReadLine();
            Employee emplo = employeeService.Update(ID, new Employee {  Adress = adres },deprName);
            if (emplo !=null)
            {
                Console.WriteLine(emplo.Name);
            }
            else
            {
                Helper.HelperMessage(ConsoleColor.DarkRed, " DOESNT  empty");
            }
        }
        public void DeleteEmployeeById()
        {
            GetAllEmployee();
        CorrectId: Helper.HelperMessage(ConsoleColor.DarkRed, "Choose  Employee's Id for Delete");
            int reslt;
            string StrId = Console.ReadLine();
            bool isConvrt = int.TryParse(StrId, out reslt);
            if (isConvrt)
            {

                if (employeeService.Delete(reslt) != null)
                {
                    Helper.HelperMessage(ConsoleColor.DarkGray, $"  {reslt}Deleted ");

                }
                else
                {
                    Helper.HelperMessage(ConsoleColor.Red, $"out of Department's Id  ");
                    goto CorrectId;
                }

            }
            else
            {
                Helper.HelperMessage(ConsoleColor.Red, " Please  enter correct Id ");
                goto CorrectId;
            }
        }
        public void Searchbydepartmen()
        {
          
           exname: Helper.HelperMessage(ConsoleColor.Magenta, "enter departmen");

            string? departmentName = Console.ReadLine();
            Department exdep = departmentRepistory.Get(d => d.Name.ToLower() == departmentName.ToLower());
            if (employeeService.Searchbydepartmen(exdep.Name) != null)
            {
                // Helper.HelperMessage(ConsoleColor.DarkMagenta, $"{exdep.Id} {exdep.Name} ");
                 foreach (var item in employeeService.Searchbydepartmen(exdep.Name))
                {
                     Helper.HelperMessage(ConsoleColor.DarkMagenta, $"{item.Id} {item.Name} {item.Surname}  ");

                }
                return;
            }
            else
            {
                Helper.HelperMessage(ConsoleColor.Red, "Department name Doesnt empty ");
                goto exname;
            }
        }
        public void GetByIdEmployee()
        {
        exisGet: Helper.HelperMessage(ConsoleColor.DarkCyan, "enter id Employee ");
            string Name;
            int GetId;
            string stGetId = Console.ReadLine();
            bool isGetId = int.TryParse(stGetId, out GetId);
            if (isGetId)
            {
                if (employeeService.Get(GetId) != null)
                {
                    Employee employe = new Employee();
                    employe.Id = GetId;

                    employe = employeeService.Get(GetId);
                    Helper.HelperMessage(ConsoleColor.DarkYellow, $" {employe.Id}  {employe.Name}");
                }
                else
                {
                    Helper.HelperMessage(ConsoleColor.Red, "have  not this employee' id ");
                    goto exisGet;
                }
            }
            else
            {
                Helper.HelperMessage(ConsoleColor.Red, "Incorrect variant ");
                goto exisGet;
            }
        }
        public void GetAllByName()
        {
            exEmple: Helper.HelperMessage(ConsoleColor.Gray, $"enter Employee' name which of see");

            string name =Console.ReadLine();
            if (name != null)
            {
                foreach (var item in employeeService.GetAll(name))
                {
                    Helper.HelperMessage(ConsoleColor.DarkGreen, $"{item.Name} {item.Surname} {item.Adress} {item.Age}");

                }
                 
               // Helper.HelperMessage(ConsoleColor.Red, $"have not with name on Employee ");
            }
            else
            {
               Helper.HelperMessage(ConsoleColor.Red, $"must not empty Employee's name ");
               goto exEmple;
            }


        }
        public void GetAllEmployee()
        {
            Helper.HelperMessage(ConsoleColor.Magenta, "List Of Employee");

            foreach (var item in employeeService.GetAll())
            {
                Helper.HelperMessage(ConsoleColor.DarkMagenta, $"{item.Id} {item.Name}   {item.Surname}  {item.Adress}  {item.department}  {item.Age}");

            }
        }
    }
}
