using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroservicesECommerce.CoreUI.Entities;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace MicroservicesECommerce.CoreUI.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetEmployees()
        {
            List<Employees> employees = new List<Employees>();
            employees = HttpHelper.HttpHelper.GetList<List<Employees>>("http://localhost:37786", "Employee/GetEmployees", Method.GET);
            return View(employees);
        }
    }
}