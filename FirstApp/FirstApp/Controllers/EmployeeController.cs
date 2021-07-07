using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FirstApp.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View(Repository.AllEmployees);
        }

        public IActionResult Create()
        {
            ViewBag.Types = new SelectList(EmployeeTaskRepository.AllEmployeeTasks.ToList(), "TaskName", "TaskName", "0");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Repository.Create(employee);
                return View("Thanks", employee);
            }
            else
                return View();
        }

        public IActionResult Update(string empname, string emplastname)
        {
            ViewBag.Types = new SelectList(EmployeeTaskRepository.AllEmployeeTasks.ToList(), "TaskName", "TaskName");
            Employee employee = Repository.AllEmployees.Where(e => e.Name == empname && e.LastName == emplastname).FirstOrDefault();
            return View(employee);
        }

        [HttpPost]
        public IActionResult Update(Employee employee, string empname, string emplastname)
        {
            ViewBag.Types = new SelectList(EmployeeTaskRepository.AllEmployeeTasks.ToList(), "TaskName", "TaskName");
            if (ModelState.IsValid)
            {
                Employee emp = Repository.AllEmployees.Where(e => e.Name == empname && e.LastName == emplastname).FirstOrDefault();
                emp.HiredDate = employee.HiredDate;               
                emp.LastName = employee.LastName;
                emp.Name = employee.Name;
                emp.TaskName = employee.TaskName;
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        [HttpPost]
        public IActionResult Delete(string empname, string emplastname)
        {
            Employee employee = Repository.AllEmployees.Where(e => e.Name == empname && e.LastName == emplastname).FirstOrDefault();
            Repository.Delete(employee);
            return RedirectToAction("Index");
        }
    }
}