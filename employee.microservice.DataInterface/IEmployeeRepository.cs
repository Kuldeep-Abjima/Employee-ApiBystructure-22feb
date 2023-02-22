using Employee.microservice.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace employee.microservice.DataInterface
{
    public interface IEmployeeRepository
    {
        public Task<bool> AddEmployee(EmployeeDto employeeDto);
    }
}
