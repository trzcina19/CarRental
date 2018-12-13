using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRental.Dtos;
using CarRental.Models;

namespace CarRental.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            //CreateMap<CustomerDto, Customer>();
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<MembershipType, MembershipTypeDto>().ReverseMap();
        }
    }
}