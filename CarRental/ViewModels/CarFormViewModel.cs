using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.ViewModels
{
    public class CarFormViewModel
    {
        public IEnumerable<TypeOfCar> TypeOfCars { get; set; }
        public Car Car { get; set; }
        public string Title
        {
            get
            {
                if (Car != null && Car.Id != 0)
                    return "Edit Car";

                return "New Car";
            }
        }




    }   
}