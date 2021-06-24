using CustomerSolutions.Models.Customer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerSolutions.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomer Customer;

        public CustomerController(ICustomer customer)
        {
            Customer = customer;
        }
        public IActionResult CustomerNameEntry()
        {
            return View();
        }
        public IActionResult CheckName(string FirstName, string LastName)
        {
            List<Customer> custList = Customer.getCustomerList();
            string message = Customer.compareData(custList, FirstName, LastName);
            ViewBag.Message = message;
            return View("CustomerNameEntry");
        }
    }
}
