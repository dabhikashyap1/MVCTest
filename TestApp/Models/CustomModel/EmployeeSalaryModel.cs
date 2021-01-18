using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestApp.Models.CustomModel
{
    public class EmployeeSalaryModel : EmployeeSalary
    {
        [NotMapped]
        public IList<SelectListItem> EmployeeSelectList { get; set; }
        [NotMapped]
        public string EmployeeName { get; set; }
    }
}