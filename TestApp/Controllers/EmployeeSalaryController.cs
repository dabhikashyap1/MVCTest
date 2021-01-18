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
    public class EmployeeSalaryController : Controller
    {
        private EmpDBContext db = new EmpDBContext();
        private readonly IEmployeeService employeeService;

        public EmployeeSalaryController()
        {
            this.employeeService = new EmployeeService();
        }
        public ActionResult Index()
        {
            List<EmployeeSalaryModel> EmployeeSalarydata = new List<EmployeeSalaryModel>();
            var emp = db.EmployeeSalary.ToList();
            if(emp != null && emp.Count > 0)
            {
                foreach(var item in emp)
                {
                    EmployeeSalaryModel EmployeeSalarysingledata = new EmployeeSalaryModel();
                    EmployeeSalarysingledata.Id = item.Id;
                    EmployeeSalarysingledata.EmpId = item.EmpId;
                    EmployeeSalarysingledata.Salary = item.Salary;
                    EmployeeSalarysingledata.EmployeeName = db.Employee.Where(m => m.ID == item.EmpId).Select(m => m.Name).FirstOrDefault();
                    
                    EmployeeSalarydata.Add(EmployeeSalarysingledata);
                }
                
            }          
            return View(EmployeeSalarydata);
        }

        // GET: EmployeeSalary/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeSalary/Create
        public ActionResult Create()
        {
            EmployeeSalaryModel EmployeeSalary = new EmployeeSalaryModel();
            EmployeeSalary.EmployeeSelectList = employeeService.GetSelectListItems();
            //EmployeeSalary.EmployeeSelectList.Add(new SelectListItem() { Text = "None", Value = null });

            return View(EmployeeSalary);
        }

        // POST: EmployeeSalary/Create
        [HttpPost]
        public ActionResult Create(EmployeeSalaryModel EmployeeSalary)
        {
            try
            {
                EmployeeSalary.EmployeeSelectList = employeeService.GetSelectListItems();
                db.EmployeeSalary.Add(EmployeeSalary);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(EmployeeSalary);
            }
        }

        // GET: EmployeeSalary/Edit/5
        public ActionResult Edit(int id)
        {
            EmployeeSalary salarydata = db.EmployeeSalary.Where(m => m.Id == id).FirstOrDefault();

            EmployeeSalaryModel EmployeeSalarydata = new EmployeeSalaryModel();
            EmployeeSalarydata.Id = salarydata.Id;
            EmployeeSalarydata.EmpId = salarydata.EmpId;
            EmployeeSalarydata.Salary = salarydata.Salary;
            EmployeeSalarydata.EmployeeSelectList = employeeService.GetSelectListItems();
            //EmployeeSalary.EmployeeSelectList.Add(new SelectListItem() { Text = "None", Value = null });

            return View(EmployeeSalarydata);
        }

        // POST: EmployeeSalary/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmployeeSalaryModel collection)
        {
            try
            {
                db.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                EmployeeSalary salarydata = db.EmployeeSalary.Where(m => m.Id == id).FirstOrDefault();

                EmployeeSalaryModel EmployeeSalarydata = new EmployeeSalaryModel();
                EmployeeSalarydata.Id = salarydata.Id;
                EmployeeSalarydata.EmpId = salarydata.EmpId;
                EmployeeSalarydata.Salary = salarydata.Salary;
                EmployeeSalarydata.EmployeeSelectList = employeeService.GetSelectListItems();
                return View(EmployeeSalarydata);
            }
        }

        // GET: EmployeeSalary/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeSalary/Delete/5
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
