using Employee.microservice.domain;
using Employee.microservice.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.microserivce.services.Infrastructure.Builder.Interface
{
    public interface IEmployeeBuilder
    {
        EmployeeDto Build(EmployeeModel empModel);
        EmployeeModel Build(EmployeeDto dto);
    }
}
