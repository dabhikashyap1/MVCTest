using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp.Models.CustomModel
{
    public class FilterSalary
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string averageSalary  { get; set; }
        public List<EmployeeCustomModel> employees { get; set; }
    }
}