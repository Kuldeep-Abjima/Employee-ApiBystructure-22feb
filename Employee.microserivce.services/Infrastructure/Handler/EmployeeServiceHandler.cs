using employee.microservice.DataInterface;
using Employee.microserivce.services.Infrastructure.Builder.Interface;
using Employee.microserivce.services.Infrastructure.Handler.Interface;
using Employee.microservice.model;
using Microsoft.Extensions.Logging;

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

        public async Task<List<EmployeeModel>> HandleGetAllEmployee()
        {
            var result = await _emloyeeRepository.GetAllEmployees();
            return result.Select(x=> _employeeBuilder.Build(x)).ToList();
        }

        public async Task<EmployeeModel> handlerGetEmployeebyId(long id)
        {
            var result = await _emloyeeRepository.GetByIdEmployee(id);
            return _employeeBuilder.Build(result);
        }

        public async Task<bool> HandlerUpdateEmployee(long id, EmployeeModel employeeModel)
        {
            var dto = _employeeBuilder.Build(employeeModel);
            var result = await _emloyeeRepository.GetByIdEmployee(id);
            if(result != null)
            {
                return await _emloyeeRepository.UpdateEmployeebyId(result.EmpId,dto);
            }
            else
            {
                _logger.LogError("employee data not found");
                return false;
            }
        }
        public async Task<bool> HandlerDeleteEmployee(long id)
        {
            var result = await _emloyeeRepository.GetByIdEmployee(id);
            if(result != null )
            {
                return await _emloyeeRepository.DeleteEmployeeById(result.EmpId);
            }
            else
            {
                _logger.LogError("employee data not found");
                return false;
            }
        }
    }
}
