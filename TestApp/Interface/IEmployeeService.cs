using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TestApp.Interface
{
    interface IEmployeeService
    {
        string CalculateYourAge(DateTime Dob);

        List<SelectListItem> GetSelectListItems();
        List<SelectListItem> GetDepartmentSelectListItems();
    }
}
