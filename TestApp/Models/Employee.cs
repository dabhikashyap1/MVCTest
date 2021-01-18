using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestApp.Models
{
    public class Employee
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter student name.")]
        public string Department { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
    }
    public class Departments
    {
        public int Id { get; set; }
        public string Department { get; set; }
    }
    //public class EmpDBContext : DbContext
    //{
    //    public EmpDBContext()
    //    { }
    //    public DbSet<Employee> Employee { get; set; }
    //}

}