using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GETForms.Web.DAL;
using GETForms.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GETForms.Web.Controllers
{

    public class CustomersController : Controller
    {
        private ICustomerDAO customerDAL;

        public CustomersController(ICustomerDAO customerDAL)
        {
            this.customerDAL = customerDAL;
        }

        public IActionResult Index()
        {
            CustomerSearch customerSearch = new CustomerSearch();
            return View(customerSearch);
        }

        public IActionResult SearchResult(CustomerSearch customerSearch)
        {
            IList<Customer> customers = customerDAL.SearchForCustomers(customerSearch.Name, customerSearch.SortMethod);

            return View(customers);
        }

    }
}