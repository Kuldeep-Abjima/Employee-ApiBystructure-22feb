using AutoMapper;
using Employee.microserivce.services.Infrastructure.Builder.Interface;
using Employee.microservice.domain;
using Employee.microservice.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.microserivce.services.Infrastructure.Builder
{
    public class EmployeeBuilder : IEmployeeBuilder
    {
        private readonly IMapper _mapper;

        public EmployeeBuilder(IMapper mapper)
        {
            _mapper = mapper;
        }

        public EmployeeDto Build(EmployeeModel empModel)
        {
            return _mapper.Map<EmployeeDto>(empModel);
        }

        public EmployeeModel Build(EmployeeDto dto) {
        
            return _mapper.Map<EmployeeModel>(dto);
        
        }

       
    }
}
