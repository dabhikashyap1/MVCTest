using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestApp.Models.CustomModel
{
    public class EmployeeCustomModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public DateTime DOB { get; set; }
        public string Age { get; set; }
        [NotMapped]
        public IList<SelectListItem> DepertmentSelectList { get; set; }
    }
}