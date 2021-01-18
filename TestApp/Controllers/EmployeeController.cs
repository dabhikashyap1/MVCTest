using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TestApp.Interface;
using TestApp.Models;
using TestApp.Models.CustomModel;
using TestApp.Service;

namespace TestApp.Controllers
{
    public class EmployeeController : Controller
    {
        private EmpDBContext db = new EmpDBContext();
        private readonly IEmployeeService employeeService;

        public EmployeeController()
        {
            this.employeeService = new EmployeeService();
        }

        // GET: Employee
        public ActionResult Index()
        {
            var emp = db.Employee.ToList();
            List<EmployeeCustomModel> employees = new List<EmployeeCustomModel>();
            if(emp != null && emp.Count > 0)
            {
                foreach(var item in emp)
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
            return View(employees);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
              IEnumerable<Departments> Colors = new List<Departments> {
                new Departments {
                    Id = 1,
                    Department = "Red"
                },
                new Departments {
                    Id = 2,
                    Department = "Blue"
                }
            };
            ViewBag.Data = Colors;
        Employee emp = db.Employee.Where(m => m.ID == id).FirstOrDefault();          
            return View(emp);
    }

    // GET: Employee/Create
    public ActionResult Create()
    {
        EmployeeCustomModel emptable = new EmployeeCustomModel();
        emptable.DepertmentSelectList = employeeService.GetDepartmentSelectListItems();
        return View(emptable);
    }

    // POST: Employee/Create
    [HttpPost]
    public ActionResult Create(EmployeeCustomModel emptable)
    {
        try
        {
                // TODO: Add insert logic here
                //emptable.Department = "IT";
                //emptable.DOB = DateTime.Now;
                //emptable.Name = "chk emp";
                Employee insertdata = new Employee();
                insertdata.ID = emptable.ID;
                insertdata.Department = emptable.Department;
                insertdata.DOB = emptable.DOB;
                insertdata.Name = emptable.Name;
                db.Employee.Add(insertdata);
                  db.SaveChanges();

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return View();
        }
    }

    // GET: Employee/Edit/5
    public ActionResult Edit(int id)
    {
        Employee emp = db.Employee.Where(m => m.ID == id).FirstOrDefault();
        return View(emp);
    }

    // POST: Employee/Edit/5
    [HttpPost]
    public ActionResult Edit(int id, Employee emptable)
    {
        try
        {
            // db.Employee.
            // db.Employee.(emptable);
            // db.Entry(countryVatMapping).State = EntityState.Modified;

            db.Entry(emptable).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }

    // GET: Employee/Delete/5
    public ActionResult Delete(int id)
    {
        Employee emp = db.Employee.Where(m => m.ID == id).FirstOrDefault();
        return View(emp);
    }

    // POST: Employee/Delete/5
    [HttpPost]
    public ActionResult Delete(int id, Employee emptable)
    {
        try
        {
            Employee dltemp = db.Employee.Where(n => n.ID == id).FirstOrDefault();

            // TODO: Add delete logic here
            db.Employee.Remove(dltemp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            return View();
        }
    }
}
}
