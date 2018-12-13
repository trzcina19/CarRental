using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CarRental.ViewModels;

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
        //    var cars = _context.Cars.Include(m => m.TypeOfCar).ToList();
            return View();
        }

        public ActionResult New()
        {
            var car = new Car { ReleaseDate = DateTime.Now };
            var typeOfCars = _context.TypeOfCars.ToList();
            var viewModel = new CarFormViewModel
            {
                Car=car,
                TypeOfCars = typeOfCars
            };
            return View("carFormViewModel", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);

            if (car == null)
                return HttpNotFound();

            var viewModel = new CarFormViewModel
            {
                Car = car,
                TypeOfCars = _context.TypeOfCars.ToList()
            };

            return View("CarFormViewModel", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Car car)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CarFormViewModel
                {
                    Car=car,
                    TypeOfCars = _context.TypeOfCars.ToList()
                };
                return View("CarFormViewModel", viewModel);
            }

            if (car.Id == 0)
            {
                car.DateAdded = DateTime.Now;
                _context.Cars.Add(car);
            }
            else
            {
                var carInDb = _context.Cars.Single(m => m.Id == car.Id);
                carInDb.Name = car.Name;
                carInDb.TypeOfCarId = car.TypeOfCarId;
                carInDb.NumberInStock = car.NumberInStock;
                carInDb.ReleaseDate = car.ReleaseDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Cars");
        }
    }
}
