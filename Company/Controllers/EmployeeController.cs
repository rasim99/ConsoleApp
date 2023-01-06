using Business.Interfaces;
using Business.Services;
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
        private readonly EmployeeService employeeService;
        public EmployeeController()
        {
            employeeService = new EmployeeService();
        }
        public void CreateEmployee()
        {

            Helper.HelperMessage(ConsoleColor.White, "Please  enter Employee's name!");

            string EmployeeName = Console.ReadLine();
            Helper.HelperMessage(ConsoleColor.White, "Please  enter Employee's Surname!");
            string EmployeeSurname = Console.ReadLine();
         Helper.HelperMessage(ConsoleColor.Blue, "Please  enter Age");
           exiAge: int Age = int.Parse(Console.ReadLine());
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
                goto exiAge;
            }
        }
        public void UpdateEmployee()
        {
            int ID = int.Parse(Console.ReadLine());
            string adres = Console.ReadLine();
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
            string departmentName = Console.ReadLine();
            Helper.HelperMessage(ConsoleColor.Magenta, "List Of Employee");
            foreach (var item in employeeService.GetAll(departmentName))
            {
                Helper.HelperMessage(ConsoleColor.DarkMagenta, $"{item.Id} {item.Name}   {item.Surname}  {item.Adress}  {item.department}  {item.Age}");

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
            string name=Console.ReadLine();
            foreach (var item in employeeService.GetAll(name) )
            {
                Helper.HelperMessage(ConsoleColor.DarkGreen, $"{item.Name} {item.Surname} {item.Adress} {item.Age}");

            }
            Helper.HelperMessage(ConsoleColor.DarkGreen, $"have not with name on Employee ");

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
