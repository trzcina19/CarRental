using CarRental.Models;
using CarRental.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRental.Controllers
{
    public class CarsController : Controller
    {
        // GET: Cars
        public ActionResult Random()
        {
            var car = new Car() { Name = "Skoda Octavia" };
            var customers = new List<Customer>
            {
                new Customer {Name="Customer 1"},
                new Customer {Name="Customer 2"}
            };

            var viewModel = new RandomCarViewModel()
            {
                Car = car,
                Customers = customers
            };


            return View(viewModel);
        }

     
    }
}