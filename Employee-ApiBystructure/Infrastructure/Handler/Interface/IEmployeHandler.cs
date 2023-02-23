using Employee.microservice.model;

namespace Employee_ApiBystructure.Infrastructure.Handler.Interface
{
    public interface IEmployeHandler
    {
        Task<bool> HandlerAddEmployeeAsync(EmployeeModel employeeModel);
        Task<List<EmployeeModel>> GetAllEmployeeAsync();
        Task<EmployeeModel> GetEmployeeByIdAsync(long id);
        Task<bool> UpdateEmployeebyIdAsync(long id, EmployeeModel employeeModel);
        Task<bool> DeleteEmployeeById(long id);
    }
}
