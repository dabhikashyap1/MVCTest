using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestApp.Models
{

    public class EmpDBContext : DbContext
    {
        public EmpDBContext()
        { }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalary { get; set; }
        
    }
}
