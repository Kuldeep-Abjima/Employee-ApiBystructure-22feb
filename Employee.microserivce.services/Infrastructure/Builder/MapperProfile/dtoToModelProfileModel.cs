using AutoMapper;
using Employee.microservice.domain;
using Employee.microservice.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.microserivce.services.Infrastructure.Builder.MapperProfile
{
    public  class dtoToModelProfileModel : Profile
    {
        public dtoToModelProfileModel()
        {
            CreateMap<EmployeeDto, EmployeeModel>();
            CreateMap<EmployeeDto, EmployeeDetailModel>();
        }
    }
}
