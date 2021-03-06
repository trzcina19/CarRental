﻿using AutoMapper;
using CarRental.Dtos;
using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace CarRental.Controllers.Api
{
    public class CarsController : ApiController
    {
        private ApplicationDbContext _context;

        public CarsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/cars
        //public IHttpActionResult GetCars()
        //{
        //    //  return _context.Cars.ToList().Select(Mapper.Map<Car, CarDto>);
        //    var carDtos = _context.Cars.
        //        Include(c => c.TypeOfCar).
        //        ToList().
        //        Select(Mapper.Map<Car, CarDto>);
        //    return Ok(carDtos);
        //}

        public IEnumerable<CarDto> GetCars(string query = null)
        {
            var carsQuery = _context.Cars
                .Include(m => m.TypeOfCar)
                .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                carsQuery = carsQuery.Where(m => m.Name.Contains(query));

            return carsQuery
                .ToList()
                .Select(Mapper.Map<Car, CarDto>);
        }



        //public IEnumerable<CarDto> GetCars(string query = null)
        //{
        //    //  return _context.Cars.ToList().Select(Mapper.Map<Car, CarDto>);
        //    var carsQuery = _context.Cars
        //                .Include(m => m.TypeOfCar)
        //                .Where(m => m.NumberAvailable > 0);

        //    if (!String.IsNullOrWhiteSpace(query))
        //        carsQuery = carsQuery.Where(m => m.Name.Contains(query));

        //    return carsQuery
        //        .ToList()
        //        .Select(Mapper.Map<Car, CarDto>);
        //}




        // GET  /api/cars/1
        public IHttpActionResult GetCar(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);

            if (car == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Car, CarDto>(car));
        }

        // POST /api/cars
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageCars)]
        public IHttpActionResult CreateCar(CarDto carDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var car = Mapper.Map<CarDto, Car>(carDto);

            _context.Cars.Add(car);
            _context.SaveChanges();
            carDto.Id = car.Id;

            return Created(new Uri(Request.RequestUri + "/" + car.Id), carDto);
        }

        // PUT /api/cars/1
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageCars)]
        public void UpdateCar(int id, CarDto carDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var carInDb = _context.Cars.SingleOrDefault(c => c.Id == id);
            if (carInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(carDto, carInDb);
            _context.SaveChanges();
        }


        // DELETE /api/cars/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageCars)]
        public void DeleteCar(int id)
        {
            var carInDb = _context.Cars.SingleOrDefault(c => c.Id == id);
            if (carInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Cars.Remove(carInDb);
            _context.SaveChanges();
        }
    }
}
