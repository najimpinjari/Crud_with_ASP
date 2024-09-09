using Crud_with_ASP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Crud_with_ASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmployeesDataAccsessLayer dal;

        public HomeController()
        {
            dal = new EmployeesDataAccsessLayer();  
        }

        public IActionResult Index()
        {
            List<Employees> emps = dal.getAllEmployee();
            return View(emps);
        }



        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employees emp)
        {
            try
            {
                dal.AddEmployee(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public IActionResult Edit( int id )
        {
            Employees emp =  dal.GetEmployeesById(id);
            return View(emp);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employees emp)
        {
            try
            {
                dal.UpdateEmploye(emp);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Details(int id)
        {
            Employees emp = dal.GetEmployeesById(id);
            return View(emp);
        }

        public IActionResult Delete(int id)
        {
            Employees emp = dal.GetEmployeesById(id);
            return View(emp);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete( Employees emp )
        {
            try
            {
                dal.DeleteEmploye(emp.Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
