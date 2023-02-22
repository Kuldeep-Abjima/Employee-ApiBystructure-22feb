using employee.microservice.DataInterface;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Employee.microservices.Data
{
    public class DataBaseFactory : Disposable, IDataBaseFactory
    {
        private readonly ILogger<IDataBaseFactory> _logger;
        private readonly string _connectionString;

        public DataBaseFactory(ILogger<IDataBaseFactory> logger, string connectionString)
        {
            _logger = logger;
            _connectionString = connectionString;
        }

        private IDbConnection _dbcontext;

        public IDbConnection Get()
        {
           if(_dbcontext == null)
            {
                try
                {
                    _dbcontext = new SqlConnection(_connectionString);
                }
                catch(Exception ex)
                {
                    _logger.LogError("expection in db connection");
                }
            }
            return _dbcontext;

        }

        protected override void DisposeCore()
        {
            if(_dbcontext != null )
            {
                _dbcontext.Dispose();
            }
        }

    }
}