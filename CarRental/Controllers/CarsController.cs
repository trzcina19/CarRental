using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CarRental.Controllers
{
    public class CarsController : Controller
    {


        private ApplicationDbContext _context;
        public CarsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var cars = _context.Cars.Include(m => m.TypeOfCar).ToList();
            return View(cars);
        }

        public ActionResult Details(int id)
        {
            var car = _context.Cars.Include(c => c.TypeOfCar).SingleOrDefault(c => c.Id == id);
            if (car == null)
                return HttpNotFound();

            return View(car);
        }





        //private IEnumerable<Car> GetCars()
        //{
        //    return new List<Car>
        //    {
        //        new Car { Id = 1, Name = "Shrek" },
        //        new Car { Id = 2, Name = "Wall-e" }
        //    };
        //}


    }
}