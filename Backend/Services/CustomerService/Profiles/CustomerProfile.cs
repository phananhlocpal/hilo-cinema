﻿using AutoMapper;
using CustomerService.Dtos;
using CustomerService.Models;

namespace CustomerService.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerReadDTO, Customer>();
            CreateMap<Customer, CustomerCreateDTO>();
        }
    }
}