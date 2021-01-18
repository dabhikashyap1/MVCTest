using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp.Interface;
using TestApp.Models;
using TestApp.Models.CustomModel;
using TestApp.Service;

namespace TestApp.Controllers
{
    public class FilterSalaryController : Controller
    {
        private EmpDBContext db = new EmpDBContext();
        private readonly IEmployeeService employeeService;

        public FilterSalaryController()
        {
            this.employeeService = new EmployeeService();
        }
        public ActionResult Index()
        {
            FilterSalary data = new FilterSalary();
            List<EmployeeCustomModel> employees = new List<EmployeeCustomModel>();
            data.employees = employees;
            return View(data);
        }

        [HttpPost]
        public ActionResult Index(FilterSalary collection)
        {
            List<Employee> data = db.Employee.Where(m => m.DOB.Year > collection.StartDate.Year && m.DOB.Year < collection.EndDate.Year).ToList();

            List<EmployeeCustomModel> employees = new List<EmployeeCustomModel>();
            if (data != null && data.Count > 0)
            {
                foreach (var item in data)
                {
                    EmployeeCustomModel newmodel = new EmployeeCustomModel();
                    newmodel.ID = item.ID;
                    newmodel.Department = item.Department;
                    newmodel.Name = item.Name;
                    newmodel.DOB = item.DOB;
                    newmodel.Age = employeeService.CalculateYourAge(item.DOB);
                    employees.Add(newmodel);
                }
            }
            string averageSalary = "";
            collection.employees = employees;

            List<int> idListint = new List<int>();
            if (data != null && data.Count > 0)
            {
                foreach (var item in data)
                {
                    if (item != null )
                    {
                        var Id = item.ID;
                        idListint.Add(Id);
                    }
                }
            }

            List<int> DistinctIds = new List<int>();
            if (idListint != null && idListint.Count > 0)
            {
                DistinctIds = idListint.Distinct().ToList();
            }

            if (DistinctIds != null && DistinctIds.Count > 0)
            {
                int i = 0;
                foreach (var item in DistinctIds)
                {
                    i = i + 1;
                    var dataselect = db.EmployeeSalary.Where(m => m.EmpId == item).ToList();
                    decimal count = 0;
                    if(dataselect != null && dataselect.Count > 0)
                    {
                        foreach(var inneritem in dataselect)
                        {
                            count = count + Convert.ToDecimal(inneritem.Salary);
                        }
                    }
                    var name = db.Employee.Where(m => m.ID == item).Select(m => m.Name).FirstOrDefault();
                    if(count == 0)
                    {
                        averageSalary = averageSalary + " " + name + ":-No salary ";
                    }
                    else if(count > 0)
                    {
                        count = count / i;
                        averageSalary = averageSalary + " " + name + ":-" + count;
                    }
                    
                }
            }

            collection.averageSalary = averageSalary;
            return View(collection);
        }

        // GET: FilterSalary/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FilterSalary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilterSalary/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FilterSalary/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FilterSalary/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: FilterSalary/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FilterSalary/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
