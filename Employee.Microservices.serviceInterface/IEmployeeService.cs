using Employee.microservice.model;

namespace Employee.Microservices.serviceInterface
{
    public interface IEmployeeService
    {
        Task<bool> AddEmployeeAsync(EmployeeModel employeeModel);
        Task<List<EmployeeModel>> GetAllEmployeeAync();
        Task<EmployeeModel> GetByIdEmployee(long id);
        Task<bool> UpdateEmployeeByid(long id, EmployeeModel employeeModel);

        Task<bool> DeleteEmployeebyid(long id);
    }
}