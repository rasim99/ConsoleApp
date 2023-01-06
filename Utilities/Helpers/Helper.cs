using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Helpers
{
    public class Helper
    {
        public static void HelperMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;

            Console.WriteLine(message);
            Console.ResetColor();
        }

        public enum Buttons
        {
             CreateDepartment=1,
            UpdateDepartment,
            DeleteByIdDepartment,
            GetByIdDepartment,
            DeleteByNameDepartment,
            GetallByCapasityDepartment,
            GetAllDepartment,
            CreateEmployee,
            UpdateEmployee,
            DeleteEmployeeById,
            Searchbydepartmen,
            GetByIdEmployee,
            GetAllEmployee,
            GetAllByName,
            ExitProgram
        };


            //Console.WriteLine(" WellCome!");
            //Console.WriteLine(" Choose one");
            //" 1- CreateDepartment" +
            //"2-UpdateDepartment" +
            //"3-DeleteByIdDepartment" +
            //"4-GetByIdDepartment" +
            //"5- DeleteByNameDepartment" +
            //"6-GetallByCapasityDepartment" +
            //"7-GetAllDepartment" +
            // 8-CreateEmployee

            //"9-ExitProgram

        
    }
}
