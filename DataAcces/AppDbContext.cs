﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public static   class AppDbContext
    {
        public static List<Department> Departments { get; set; }
        public static List<Employee> Employees { get; set; }
        static  AppDbContext()
        {
            Departments= new List<Department>();
            Employees= new List<Employee>();
        }
    }
        
}
