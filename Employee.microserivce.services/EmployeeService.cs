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

        public async Task<bool> AddEmployeeAsync(EmployeeModel employeeModel)
        {
      
            return await _employeeServiceHandler.HandleAddEmployee(employeeModel);
        }
        public async Task<List<EmployeeModel>> GetAllEmployeeAync()
        {
            return await _employeeServiceHandler.HandleGetAllEmployee();
        }

        public async Task<EmployeeModel> GetByIdEmployee(long id)
        {
            return await _employeeServiceHandler.handlerGetEmployeebyId(id);   
        }
        public async Task<bool> UpdateEmployeeByid(long id, EmployeeModel employeeModel)
        {
            return await _employeeServiceHandler.HandlerUpdateEmployee(id, employeeModel);
        }
        public async Task<bool> DeleteEmployeebyid(long id)
        {
            return await _employeeServiceHandler.HandlerDeleteEmployee(id);
        }
    }
}