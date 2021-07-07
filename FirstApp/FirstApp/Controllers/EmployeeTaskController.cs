using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstApp.Controllers
{
    public class EmployeeTaskController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<EmployeeTask> tasks = EmployeeTaskRepository.AllEmployeeTasks;
            return View(tasks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeTask task)
        {
            if (ModelState.IsValid)
            {
                EmployeeTaskRepository.Create(task);                
                return View("Thanks", task);
            }
            else
                return View();
        }

        public IActionResult Update(string taskname)
        {
            EmployeeTask task = EmployeeTaskRepository.AllEmployeeTasks.Where(e => e.TaskName == taskname).FirstOrDefault();
            return View(task);
        }

        [HttpPost]
        public IActionResult Update(EmployeeTask task, string taskname)
        {
            if (ModelState.IsValid)
            {
                EmployeeTask et = EmployeeTaskRepository.AllEmployeeTasks.Where(e => e.TaskName == taskname).FirstOrDefault();
                et.TaskName = task.TaskName;
                et.StartDate = task.StartDate;
                et.EndDate = task.EndDate;
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        [HttpPost]
        public IActionResult Delete(string taskname)
        {
            EmployeeTask employeetask = EmployeeTaskRepository.AllEmployeeTasks.Where(e => e.TaskName == taskname).FirstOrDefault();
            EmployeeTaskRepository.Delete(employeetask);
            return RedirectToAction("Index");
        }
    }
}