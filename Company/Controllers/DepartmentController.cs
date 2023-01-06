
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
    public  class DepartmentController
    {
         
        private readonly DepartmentServices departmentServices;
        public void Mainmessage()
        {
            Helper.HelperMessage(ConsoleColor.Green, "WellCome!" + "   " +

    "1- CreateDepartment" +
    "2-UpdateDepartment" +
    "3-DeleteByIdDepartment" +
    "4-GetByIdDepartment" +
    "5- DeleteByNameDepartment" +
    "6-GetallByCapasityDepartment" +
    "7-GetAllDepartment" +
    "8-CreateEmployee"+
    "9-UpdateEmployee" +
    "10-DeleteEmployeeById" +
    " 11-Searchbydepartmen" +
     "12-GetByIdEmployee" +
     "13-GetAllEmployee" +
    "14-GetAllByName" +
    "15- exit program" );

        }
        public DepartmentController()
        {
            departmentServices = new DepartmentServices();
        }
        public  void CreateDepartment()
        {
            Helper.HelperMessage(ConsoleColor.White, "Please  enter Department's name!");

            string DepartmentName = Console.ReadLine();
        enterCapasity: Helper.HelperMessage(ConsoleColor.Blue, "Please  enter Capasity");
            int Capasity;
            string StringCapasity = Console.ReadLine();
            bool CapasityResult = int.TryParse(StringCapasity, out Capasity);
            if (CapasityResult)
            {
                Department department = new Department();
                department.Name = DepartmentName;
                department.Capasity = Capasity;
                
                Department newDepartment = departmentServices.Create(department);
                Helper.HelperMessage(ConsoleColor.DarkYellow, $" Created of {newDepartment.Name}");

                
            }
            else
            {
                Helper.HelperMessage(ConsoleColor.DarkRed, "Not true Capasity format ");

                goto enterCapasity;
            }
        }
        public void UpdateDepartment()
        {
        //Helper.HelperMessage(ConsoleColor.Cyan, "'enter name for udpate department");
        //Department exd = departmentServices.Update(1, new Department { Name=Console.ReadLine(),Capasity=100});
        //if (exd !=null)
        //{
        //    Console.WriteLine(exd.Name,exd.Capasity);
        //}
        //else
        //{
        //    Console.WriteLine("eror somthing");
        //}

        CorrectId: Helper.HelperMessage(ConsoleColor.DarkGreen, "Choose  Department's Id for Update");
            int resId;
            string StrId = Console.ReadLine();
            bool isConvrt = int.TryParse(StrId, out resId);
            Department dep = new Department();
            if (isConvrt)
            {
                Department exd = departmentServices.Update(resId, dep);
                if (departmentServices.Update(resId, exd) != null)
                {
                    Helper.HelperMessage(ConsoleColor.Yellow, "Choose  Department's Name for Update");
                    string departmentName = Console.ReadLine();
                    Helper.HelperMessage(ConsoleColor.Yellow, "Choose  Department's Capasity for Update");

                    int DepCapasity;
                    string DeStrCap = Console.ReadLine();
                    bool isDepCaps = int.TryParse(DeStrCap, out DepCapasity);
                    Department department = new Department();
                    department.Name = departmentName;
                    department.Capasity = DepCapasity;
                    Department newDepartment = departmentServices.Update(resId, department);
                    Helper.HelperMessage(ConsoleColor.DarkYellow, $"Updated   {newDepartment.Name} {newDepartment.Capasity}");

                }
                else
                {
                    Console.WriteLine("erooooooor");
                    Helper.HelperMessage(ConsoleColor.Red, "out of Id ");
                    goto CorrectId;
                }

            }
            else
            {
                Helper.HelperMessage(ConsoleColor.Red, "Please coose correct Id");
                goto CorrectId;
            }
        }
        public void DeleteDepartmentById()
        {
            GetAllDepartment();
        CorrectId: Helper.HelperMessage(ConsoleColor.DarkRed, "Choose  Department's Id for Delete");
            int reslt;
            string StrId = Console.ReadLine();
            bool isConvrt = int.TryParse(StrId, out reslt);
            if (isConvrt)
            {

                if (departmentServices.Delete(reslt) != null)
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

        public void GetByIdDepartment()
        {  
            exisGet: Helper.HelperMessage(ConsoleColor.DarkCyan, "enter id Department ");
            string Name;
            int GetId;
            string stGetId = Console.ReadLine();
            bool isGetId = int.TryParse(stGetId, out GetId);
           if (isGetId)
            {
                if (departmentServices.Get(GetId) != null)
                {
                    Department department = new Department();
                    department.Id = GetId;

                    department = departmentServices.Get(GetId);
                    Helper.HelperMessage(ConsoleColor.DarkYellow, $" {department.Id}  {department.Name}");
                }
                else
                {
                    Helper.HelperMessage(ConsoleColor.Red, "have  not this departmen' id ");
                    goto exisGet;
                }
            }
            else
            {
                Helper.HelperMessage(ConsoleColor.Red, "Incorrect variant ");
                goto exisGet;
            }
        }

        public void DeleteByNameDepartment()
        {
            GetAllDepartment();
        CorrectId: Helper.HelperMessage(ConsoleColor.DarkRed, "Choose  Department's Name for Delete");
            string DepName = Console.ReadLine();
            if (departmentServices.Delete(DepName) != null)
            {
                Helper.HelperMessage(ConsoleColor.DarkGray, $"  {DepName}Deleted ");
            }

        }

        public void GetallByCapasityDepartment()
        {
        CorrectCapasity: Helper.HelperMessage(ConsoleColor.DarkBlue, "Choose  Department's Capasity");
            int resCapasity;
            string stCapasity = Console.ReadLine();
            bool isCaps = int.TryParse(stCapasity, out resCapasity);
            if (isCaps)
            {
                foreach (var item in departmentServices.GetAll(resCapasity) )
                {
                Helper.HelperMessage(ConsoleColor.DarkGreen, $"{item.Name}");
                }
                Helper.HelperMessage(ConsoleColor.DarkGreen, $"1have not this capasity department");


            }
            else
            {
            Helper.HelperMessage(ConsoleColor.DarkRed, "Choose correct Department's capasity");
                goto CorrectCapasity;
            }
        }
        public void GetAllDepartment()
        {
            Helper.HelperMessage(ConsoleColor.Magenta, "List Of Departments");

            foreach (var item in departmentServices.GetAll())
            {
                Helper.HelperMessage(ConsoleColor.DarkMagenta, $"{item.Id} {item.Name} {item.Capasity}");

            }
        }
    }
}
