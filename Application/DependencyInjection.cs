using Application.Repository;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;


namespace Application
{
    public class DependencyInjectionOptions
    {
        public Assembly[]? AutoMapperAssemblies { get; set; }
    }

    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDependencyInjections(this IServiceCollection services,
            IConfiguration configuration, DependencyInjectionOptions options)
        {
            //var contentRoot = Environment.Con;

            services.AddMemoryCache();
            services
            .ConfigureServices()
            .ConfigureDatabase(configuration)
            .AddRepositories()
            .ConfigureAutoMapper(options.AutoMapperAssemblies)
            .AddMediator();

            return services;
        }


        private static IServiceCollection ConfigureDatabase(this IServiceCollection services,
    IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseNpgsql(configuration.GetConnectionString("DefaultPostgres")));
            return services;
        }

        private static IServiceCollection ConfigureAutoMapper(this IServiceCollection services, Assembly[] assemblies)
        {
            services.AddAutoMapper(assemblies);
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // i assume your service interfaces inherit from IRepositoryBase<>
            Assembly ass = typeof(IRepositoryIdentifier).GetTypeInfo().Assembly;

            // get all concrete types which implements IRepositoryIdentifier
            var allRepositories = ass.GetTypes().Where(t =>
                t.GetTypeInfo().IsClass &&
                !t.IsGenericType &&
                !t.GetTypeInfo().IsAbstract &&
                typeof(IRepositoryIdentifier).IsAssignableFrom(t));

            foreach (var type in allRepositories)
            {
                var allInterfaces = type.GetInterfaces();
                var mainInterfaces = allInterfaces.Where(t => typeof(IRepositoryIdentifier) != t && (!t.IsGenericType || t.GetGenericTypeDefinition() != typeof(IRepository<>)));
                foreach (var itype in mainInterfaces)
                {
                    if (allRepositories.Any(x => x != type && itype.IsAssignableFrom(x)))
                    {
                        throw new Exception("The " + itype.Name + " type has more than one implementations, please change your filter");
                    }
                    services.AddScoped(itype, type);
                }
            }
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        private static IServiceCollection ConfigureServices(this IServiceCollection services)
        {

            return services;
        }

        public static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services
                .AddMediatR(cfg =>
                {
                    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());

                });
            return services;
        }


    }
}
