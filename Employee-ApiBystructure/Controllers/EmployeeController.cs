using Azure;
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
        [HttpGet]
        [Route("[Controller]GetAll")]
        public async Task<ResponseWrapper<List<EmployeeModel>>> GetAll()
        {
            var reponse = new ResponseWrapper<List<EmployeeModel>>();
            try
            {
                reponse.set(await _employeHandler.GetAllEmployeeAsync());
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,$"exception in EmployeeController/getall {ex}");
                reponse.set(ex);
            }
            return reponse;
        }

        [HttpGet]
        [Route("[Controller]GetById")]
        public async Task<ResponseWrapper<EmployeeModel>> GetById(long id)
        {
            var response = new ResponseWrapper<EmployeeModel>();
            try
            {
                response.set(await _employeHandler.GetEmployeeByIdAsync(id));
            }catch(Exception ex)
            {
                _logger.LogError(ex, $"exception in EmployeeController/getbyid {ex}");
                response.set(ex);
            }
            return response;
        }
        [HttpPost]
        [Route("[Controller]UpdateById/{id}")]
        public async Task<ResponseWrapper<bool>> UpdateById(long id, EmployeeModel employeeModel)
        {
            var response = new ResponseWrapper<bool>();
            try
            {
                var result = await _employeHandler.UpdateEmployeebyIdAsync(id, employeeModel);
                response.set(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"exception in EmployeeController/updatebyid {ex}");
                response.set(ex);
            }
            return response;
        }

        [HttpDelete]
        [Route("[Controller]UpdateById")]
        public async Task<ResponseWrapper<bool>> DeleteById(long id)
        {
            var response = new ResponseWrapper<bool>();
            try
            {
                var result = await _employeHandler.DeleteEmployeeById(id);
                response.set(result);
            }catch(Exception ex)
            {
                _logger.LogError(ex, $"exception in EmployeeController/deletebyid {ex}");
                response.set(ex);
            }
            return response;

        }
    }
}
