using Employee.microservice.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.microserivce.services.Infrastructure.Handler.Interface
{
    public interface IEmployeeServiceHandler
    {
        Task<bool> HandleAddEmployee(EmployeeModel employeeModel);
    }
}
