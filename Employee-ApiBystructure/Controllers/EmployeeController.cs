using Employee.microservice.model;
using Employee_ApiBystructure.Infrastructure.Handler.Interface;
using Employee_ApiBystructure.Infrastructure.ResponseWrapper;
using Microsoft.AspNetCore.Mvc;

namespace Employee_ApiBystructure.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeHandler _employeHandler;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeHandler employeHandler)
        {
            _logger = logger;
            _employeHandler = employeHandler;
        }

        [HttpPost]
        [Route("[Controller]Add")]
        public async Task<ResponseWrapper<bool>> Add(EmployeeModel employeeModel)
        {
            var response = new ResponseWrapper<bool>();
            try
            {
                response.set(await _employeHandler.HandlerAddEmployeeAsync(employeeModel));

            }
            catch (Exception ex)
            {
               _logger.LogError(ex, $"exception in EmployeeController/Add {ex}");
                response.set(ex);
            }
            return response;
        }
    }
}
