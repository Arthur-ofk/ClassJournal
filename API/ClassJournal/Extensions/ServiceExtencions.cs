using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository;
using Services;
using Services.Contracts;

namespace ClassJournal.Extensions
{
    public static class ServiceExtencions
    {
        //public static void ConfigSet(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}
        //public static IConfiguration Configuration { get; set; }
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                    );
            }
            );
            //services.AddDbContext<RepositoryContext>(options =>
            //{
            //    //options.UseLazyLoadingProxies(); 
            //    options.UseSqlServer(Configuration.GetConnectionString("sqlConnection"));
            //});
        }
        public static void ConfigureServiceManager(this IServiceCollection services) =>
         services.AddScoped<IServiceManager, ServiceManager>();
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {


            });
        public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
        services.AddScoped<IRepositoryManager, RepositoryManager>();
        public static void ConfigureSqlContext(this IServiceCollection services,
        IConfiguration configuration) =>
        services.AddDbContext<RepositoryContext>(opts =>
        opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));


    }
}
