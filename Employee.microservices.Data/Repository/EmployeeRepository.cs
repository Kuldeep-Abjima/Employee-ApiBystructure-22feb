using Dapper;
using employee.microservice.DataInterface;
using Employee.microservice.domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.microservices.Data.Repository
{
    public class EmployeeRepository : BaseRepository<EmployeeDto>, IEmployeeRepository
    {
        private readonly ILogger<IEmployeeRepository> _logger;

        public EmployeeRepository(ILogger<IEmployeeRepository> logger, IDataBaseFactory DataBaseFactory) : base(logger, DataBaseFactory) 
        {
            _logger = logger;
        }

        public async Task<bool> AddEmployee(EmployeeDto employeeDto)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@identifier", employeeDto.Identifier);
            parameter.Add("@EmployeeName", employeeDto.Name);
            parameter.Add("@Email",employeeDto.Email);
            parameter.Add("@Category", employeeDto.Category);
            parameter.Add("@Gender", employeeDto.Gender);
            parameter.Add("@createdat", employeeDto.Createdat);
            parameter.Add("@updatedat", employeeDto.Updatedat);
            var result = Datacontext.QueryFirstOrDefault<int>("AddEmployee", parameter, commandType: System.Data.CommandType.StoredProcedure);
            return result > 0 ? true : false;

        }
        

        

    }
}
