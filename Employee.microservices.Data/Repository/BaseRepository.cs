using employee.microservice.DataInterface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.microservices.Data.Repository
{
    public class BaseRepository<T> where T : class
    {
        private readonly ILogger _logger;
        private IDbConnection _dbContext;

        public BaseRepository(ILogger logger, IDataBaseFactory dataBaseFactory) 
        {
            _logger = logger;
            _dataBaseFactory = dataBaseFactory;
        }

        protected IDataBaseFactory _dataBaseFactory
        {
            get; 
            private set;
        }

        protected IDbConnection Datacontext
        {
            get { return _dbContext ??= _dataBaseFactory.Get();  }
        }
    }
}
