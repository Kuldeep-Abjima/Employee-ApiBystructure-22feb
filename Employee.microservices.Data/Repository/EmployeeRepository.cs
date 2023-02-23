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
            parameter.Add("@EmployeeName", employeeDto.EmployeeName);
            parameter.Add("@Email",employeeDto.Email);
            parameter.Add("@Category", employeeDto.Category);
            parameter.Add("@Gender", employeeDto.Gender);
            parameter.Add("@createdat", employeeDto.Createdat);
            parameter.Add("@updatedat", employeeDto.Updatedat);
            var result = Datacontext.QueryFirstOrDefault<int>("AddEmployee", parameter, commandType: System.Data.CommandType.StoredProcedure);
            return result > 0 ? true : false;

        }

        public async Task<List<EmployeeDto>> GetAllEmployees()
        {
            var result = await Datacontext.QueryAsync<EmployeeDto>("select * from employee", commandType: System.Data.CommandType.Text);
            return result.ToList();
        }

        public async Task<EmployeeDto> GetByIdEmployee(long id)
        {
            var para = new DynamicParameters();
            para.Add("@id", id);
            var result = await Datacontext.QueryFirstOrDefaultAsync<EmployeeDto>($"sp_GetByIdEmployee", para, commandType: System.Data.CommandType.StoredProcedure);
            return result;
        }
        
        public async Task<bool> UpdateEmployeebyId(long id, EmployeeDto employeeDto)
        {
            var para = new DynamicParameters();
            para.Add("@id", id);
            para.Add("@employeeName", employeeDto.EmployeeName);
            para.Add("@email", employeeDto.Email);
            para.Add("@category", employeeDto.Category);
            para.Add("@gender", employeeDto.Gender);
            para.Add("@updatedat", employeeDto.Updatedat);
            var result = await Datacontext.QueryFirstOrDefaultAsync<int>("sp_updateEmployeebyId", para, commandType: System.Data.CommandType.StoredProcedure);
            return result > 0 ? true : false;
        }

        
        public async Task<bool> DeleteEmployeeById(long id)
        {
            var para = new DynamicParameters();
            para.Add("@id",id);
            var result = await Datacontext.QueryFirstOrDefaultAsync<int>("sp_deleteEmployeeById", para, commandType: System.Data.CommandType.StoredProcedure);
            return result > 0 ? true : false;

        }
    }
}
