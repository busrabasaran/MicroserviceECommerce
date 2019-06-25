using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroservicesECommerce.CoreUI.Entities;
using MicroservicesECommerce.CoreUI.HttpHelper;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace MicroservicesECommerce.CoreUI.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCustomers()
        {
            List<Customers> customers = new List<Customers>();
            customers = CustomerHelper.GetList<List<Customers>>("http://localhost:37776", "Customer/GetCustomers", Method.GET);
            return View(customers);
        }
        public IActionResult GetCustomer()
        {

            Customers customers = CustomerHelper.GetList<Customers>("http://localhost:37776", "Customer/FindCustomer", Method.GET);
            return View(customers);
        }

        public IActionResult EditCustomer(string id)
        {

            Customers customer = CustomerHelper.GetDetail<Customers>("http://localhost:37776/", "Customer/FindCustomer", Method.GET, id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult EditCustomer(Customers customer)
        {
            CustomerHelper.Update<Customers>("http://localhost:37776/", "Customer/UpdateCustomer", Method.POST, customer);
            return RedirectToAction("GetCustomers");
        }

        public IActionResult DeleteCustomer(string id)
        {
            CustomerHelper.Delete<Customers>("http://localhost:37776/", "Customer/DeleteCustomer", Method.GET, id);
            return RedirectToAction("GetCustomers");
        }
    }
}