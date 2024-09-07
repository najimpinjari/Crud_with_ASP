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


    }
}
