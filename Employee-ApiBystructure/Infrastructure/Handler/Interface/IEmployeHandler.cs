using Employee.microservice.model;

namespace Employee_ApiBystructure.Infrastructure.Handler.Interface
{
    public interface IEmployeHandler
    {
        Task<bool> HandlerAddEmployeeAsync(EmployeeModel employeeModel);
    }
}
