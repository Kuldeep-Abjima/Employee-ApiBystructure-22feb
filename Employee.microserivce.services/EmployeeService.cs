using Employee.microserivce.services.Infrastructure.Handler.Interface;
using Employee.microservice.model;
using Employee.Microservices.serviceInterface;

namespace Employee.microserivce.services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeServiceHandler _employeeServiceHandler;

        public EmployeeService(IEmployeeServiceHandler employeeServiceHandler)
        {
           _employeeServiceHandler = employeeServiceHandler;
        }

        public async Task<bool> AddStudentAsync(EmployeeModel employeeModel)
        {
      
            return await _employeeServiceHandler.HandleAddEmployee(employeeModel);
        }
    }
}