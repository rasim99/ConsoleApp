// See https://aka.ms/new-console-template for more information
using ACompany.Controllers;
using Business.Services;
using Entities.Models;
using System.ComponentModel.Design;
using System.Data.Entity.Infrastructure;
using Utilities.Helpers;


DepartmentServices departmentService = new();
DepartmentController departmentController = new();
EmployeeController employeeController = new();
departmentController.Mainmessage();

bool whileResult=true;
while (whileResult)
{
    Helper.HelperMessage(ConsoleColor.White, "Choose one");

    string ChooseOnebyMenu = Console.ReadLine();
    int Button;
    bool result = int.TryParse(ChooseOnebyMenu, out Button);

    if (result && Button<15 && Button >0)
    {
        switch (Button)
        {
            case(int) Helper.Buttons.CreateDepartment :
                departmentController.CreateDepartment();         
                break;


            case (int)Helper.Buttons.UpdateDepartment:
                departmentController.UpdateDepartment();           
                break;


            case (int)Helper.Buttons.DeleteByIdDepartment:
                departmentController. DeleteDepartmentById();
                break;

            case (int)Helper.Buttons.GetByIdDepartment:
                departmentController.GetByIdDepartment();
                break;
            case (int) Helper.Buttons.DeleteByNameDepartment:
                departmentController.DeleteByNameDepartment();
                break;

            case (int)Helper.Buttons.GetallByCapasityDepartment:
                departmentController.GetallByCapasityDepartment();
                break;
            case (int)Helper.Buttons.GetAllDepartment:
                departmentController.GetAllDepartment();
                break;

            case (int)Helper.Buttons.CreateEmployee:
                employeeController.CreateEmployee();
                break;

            case (int)Helper.Buttons.UpdateEmployee:
                employeeController.UpdateEmployee();
                break;

            case (int)Helper.Buttons.DeleteEmployeeById:
                employeeController.DeleteEmployeeById();
                break;

            case (int)Helper.Buttons.Searchbydepartmen:
                employeeController.Searchbydepartmen();
                break;

            case (int)Helper.Buttons.GetByIdEmployee:
                employeeController.GetByIdEmployee();
                break;

            case (int)Helper.Buttons.GetAllEmployee:
                employeeController.GetAllEmployee();
                break;

            case (int)Helper.Buttons.GetAllByName:
                employeeController.GetAllByName();
                break;

                case (int)Helper.Buttons.ExitProgram:

               whileResult = false;
                break; 


            default:
                break;
                
        }
    }
    else
    {
        Helper.HelperMessage(ConsoleColor.DarkRed, "out of buttons" +" " +"please correct button ");     
    }
    
   
}

