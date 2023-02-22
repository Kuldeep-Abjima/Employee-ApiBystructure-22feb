using Employee.microservice.model;

namespace Employee.Microservices.serviceInterface
{
    public interface IEmployeeService
    {
        Task<bool> AddStudentAsync(EmployeeModel employeeModel);

    }
}