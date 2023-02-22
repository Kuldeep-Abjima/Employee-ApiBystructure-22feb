using employee.microservice.DataInterface;
using Employee.microserivce.services.Infrastructure.Builder.Interface;
using Employee.microserivce.services.Infrastructure.Handler.Interface;
using Employee.microservice.model;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.microserivce.services.Infrastructure.Handler
{
    public class EmployeeServiceHandler : IEmployeeServiceHandler
    {
        private readonly ILogger<IEmployeeServiceHandler> _logger;
        private readonly IEmployeeBuilder _employeeBuilder;
        private readonly IEmployeeRepository _emloyeeRepository;

        public EmployeeServiceHandler(ILogger<IEmployeeServiceHandler> logger, IEmployeeBuilder employeeBuilder, IEmployeeRepository emloyeeRepository) 
        {
            _logger = logger;
            _employeeBuilder = employeeBuilder;
            _emloyeeRepository = emloyeeRepository;
        }

        public async Task<bool> HandleAddEmployee(EmployeeModel employeeModel)
        {
            var dto = _employeeBuilder.Build(employeeModel);
            return await _emloyeeRepository.AddEmployee(dto);
        }

    }
}
