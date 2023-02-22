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
                result =  await _employeeService.AddStudentAsync(employeeModel);
                
            }
            catch(Exception ex)
            {

            }
            return result;
           
        }
    }
}
