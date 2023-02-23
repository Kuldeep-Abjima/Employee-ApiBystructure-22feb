using Employee.microservice.model;
using Employee.Microservices.serviceInterface;
using Employee_ApiBystructure.Infrastructure.Handler.Interface;

namespace Employee_ApiBystructure.Infrastructure.Handler
{
    public class EmployeHandler : IEmployeHandler
    {
        private readonly ILogger<IEmployeHandler> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeHandler(ILogger<IEmployeHandler> logger, IEmployeeService employeeService) 
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        public async Task<bool> HandlerAddEmployeeAsync(EmployeeModel employeeModel)
        {
            bool result = false;
            try
            {
                if (employeeModel == null)
                {
                    _logger.LogError($"EmployeeHandle/AddEmployeeAsnyc null value pass");
                    throw new ArgumentNullException(nameof(employeeModel));

                }
                result =  await _employeeService.AddEmployeeAsync(employeeModel);
                
            }
            catch(Exception ex)
            {

            }
            return result;
           
        }
        public async Task<List<EmployeeModel>> GetAllEmployeeAsync()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            try
            {
                employees = await _employeeService.GetAllEmployeeAync();
                if(employees == null)
                {
                    _logger.LogError($"EmployeeHandle/GetAllEmployeesAsnc null");
                    throw new ArgumentNullException(nameof(employees));
                }
            }
            catch(Exception ex)
            {

            }
            return employees;
        }
        public async Task<EmployeeModel> GetEmployeeByIdAsync(long id)
        {
            var employee = new EmployeeModel();
            try
            {
                employee = await _employeeService.GetByIdEmployee(id);
                if (employee == null)
                {
                    _logger.LogError($"EmployeeHandle/GetbyidEmployeesAsnc null");
                    throw new ArgumentNullException(nameof(employee));
                }
            }
            catch(Exception ex)
            {

            }
            return employee;
        }
        public async Task<bool> UpdateEmployeebyIdAsync(long id,EmployeeModel employeeModel)
        {
            var result = false;
            try
            {
                if(id == null || employeeModel == null)
                {
                    _logger.LogError($"EmployeeHandle/GetAllEmployeesAsnc null");
                    throw new ArgumentNullException(nameof(employeeModel));

                }
                result = await _employeeService.UpdateEmployeeByid(id, employeeModel);
                
            }catch(Exception ex)
            {

            }
            return result;
        }
        public async Task<bool> DeleteEmployeeById(long id)
        {
            var result = false;
            try
            {
                if (id == null)
                {
                    _logger.LogError($"EmployeeHandle/GetAllEmployeesAsnc null");
                    throw new ArgumentNullException(nameof(id));

                }
                result = await _employeeService.DeleteEmployeebyid(id);
            }
            catch(Exception ex)
            {

            }
            return result;

        }
    }
}
