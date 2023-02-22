using employee.microservice.DataInterface;
using Employee.microserivce.services;
using Employee.microserivce.services.Infrastructure.Builder.MapperProfile;
using Employee.microserivce.services.Infrastructure.Handler;
using Employee.microserivce.services.Infrastructure.Handler.Interface;
using Employee.microservice.model;
using Employee.microservices.Data;
using Employee.Microservices.serviceInterface;
using Employee_ApiBystructure.Controllers;
using Employee_ApiBystructure.Infrastructure.Handler;
using Employee_ApiBystructure.Infrastructure.Handler.Interface;
using Scrutor;
using System.Reflection.Metadata.Ecma335;

namespace Employee_ApiBystructure
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddCustomMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(dtoToModelProfileModel));
            services.AddAutoMapper(typeof(modelToDtoMapperProfile));
            return services;
        }
        public static IServiceCollection AddCustomAssimblies(this IServiceCollection services)
        {
            var type = new List<Type>()
            {
              typeof(IDataBaseFactory),
              typeof(DataBaseFactory),
              typeof(IEmployeeService),
              typeof(EmployeeService),
              typeof(IEmployeeServiceHandler),
              typeof(EmployeeServiceHandler),
              typeof(IEmployeHandler),
              typeof(EmployeHandler),
              typeof(EmployeeController)

            };
            services.Scan(scan => scan
                .FromAssembliesOf(type)
                .AddClasses()
                .UsingRegistrationStrategy(RegistrationStrategy.Skip)
                .AsMatchingInterface()
                .WithScopedLifetime());
            services.AddTransient<EmployeeModel>();
            return services;
        }

        public static IServiceCollection AddCustomDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDataBaseFactory>(sp =>
            {
                return new DataBaseFactory(sp.GetRequiredService<ILogger<IDataBaseFactory>>(), configuration.GetConnectionString("DBConnection"));
            });
            return services;
        }
    }
}
