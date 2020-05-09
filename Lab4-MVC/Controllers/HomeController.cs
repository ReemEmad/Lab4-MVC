
using Lab4_MVC.DAL;
using Lab4_MVC.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Lab4_MVC.Controllers
{
    public class HomeController : Controller
    {
        ModelContext ctx = new ModelContext();

        [HttpGet]
        public ActionResult Index()
        {
            return View(ctx.Employees.ToList());
        }

        //Add Employee
        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Action = "Add";
            return View("EmployeeForm");
        }

        [HttpPost]
        public ActionResult Contact(Employee emp)
        {
           

            if (ModelState.IsValid)
            {
                ctx.Employees.Add(emp);
                ctx.SaveChanges();
                return View("About", ctx.Employees.ToList());

            }
            ViewBag.Action = "Add";
            return View("EmployeeForm");
        }
      
        public ActionResult About(Employee emp)
        {
            return View(ctx.Employees.ToList());

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            Employee employee = ctx.Employees.Find(id);
            if (employee!=null)
            {
                ViewBag.Action = "Edit";
                return View("EmployeeForm",employee);

            }
            
            return HttpNotFound("Employee not found");
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                ctx.Employees.Attach(employee);
                ctx.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return View("About", ctx.Employees.ToList());
            }
            ViewBag.Action = "Edit";
            return View("EmployeeForm");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Employee employee = ctx.Employees.Find(id);
            if (employee != null)
            {
                ctx.Employees.Remove(employee);
                ctx.SaveChanges();
                return Json(true);
            }
            return HttpNotFound("Employee not found");

        }
    }
}