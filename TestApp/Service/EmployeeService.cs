using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp.Interface;
using TestApp.Models;

namespace TestApp.Service
{
    public class EmployeeService : IEmployeeService
    {
        private EmpDBContext db = new EmpDBContext();
        public string CalculateYourAge(DateTime Dob)
        {
            DateTime Now = DateTime.Now;
            var sa = DateTime.Now.Subtract(Dob);
            int Years = new DateTime(DateTime.Now.Subtract(Dob).Ticks).Year - 1;
            DateTime PastYearDate = Dob.AddYears(Years);
            int Months = 0;
            for (int i = 1; i <= 12; i++)
            {
                if (PastYearDate.AddMonths(i) == Now)
                {
                    Months = i;
                    break;
                }
                else if (PastYearDate.AddMonths(i) >= Now)
                {
                    Months = i - 1;
                    break;
                }
            }
            int Days = Now.Subtract(PastYearDate.AddMonths(Months)).Days;
            int Hours = Now.Subtract(PastYearDate).Hours;
            int Minutes = Now.Subtract(PastYearDate).Minutes;
            int Seconds = Now.Subtract(PastYearDate).Seconds;
            return String.Format("Age: {0} Year(s) {1} Month(s) {2} Day(s) {3} Hour(s) {4} Second(s)",
            Years, Months, Days, Hours, Seconds);
        }

        public List<SelectListItem> GetSelectListItems()
        {
            try
            {
                //List<SelectListItem> daa = new List<SelectListItem>();
                //daa.Add( new SelectListItem() { Value = 45.ToString(), Text = 5656.ToString() });
                return db.Employee
                    .OrderBy(r => r.ID)
                    .Select(r => new SelectListItem { Value = r.ID.ToString(), Text = r.Name })
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SelectListItem> GetDepartmentSelectListItems()
        {
            try
            {
                List<SelectListItem> data = new List<SelectListItem>();
                data.Add( new SelectListItem() { Value = "computer", Text = "computer" });
                data.Add(new SelectListItem() { Value = "it", Text = "it" });
                data.Add(new SelectListItem() { Value = "electrical", Text = "electrical" });
                data.Add(new SelectListItem() { Value = "mechanical", Text = "mechanical" });
                data.Add(new SelectListItem() { Value = "civil", Text = "civil" });


                return data;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}