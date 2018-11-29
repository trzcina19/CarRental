using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.ViewModels
{
    public class RandomCarViewModel
    {
        public Car Car { get; set; }
        public List<Customer> Customers{ get; set; }
    }
}