using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Journal.Database.Registration;
using Journal.Registrations;
using ContextRegistrationParams = Journal.Database.Registration.Dependencies.ContextRegistrationParams;
using Journal.Database;

namespace Journal.Tests.Environment
{
    public class EnvironmentBase
    {
        protected readonly IServiceCollection ServiceCollection = new ServiceCollection();
        protected ServiceProvider? Services;

        public static DateTime BirthDay { get; set; } = DateTime.MaxValue;

        public EnvironmentBase()
        {
            RegisterServices();
        }

        public virtual void AdjustEnvironment(IServiceCollection services)
        {
        }

        public void RegisterServices()
        {
            ServiceCollection.AddSingleton<ILoggerFactory, LoggerFactory>();
            ServiceCollection.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
            ServiceCollection.AddScoped<Pages.IndexModel>();

            var regParams = new ContextRegistrationParams
            {
                InMemoryServer = false,
                ConnectionString = @$"Server=(local);Database={DatabaseConstants.DatabaseName};Trusted_Connection=True;TrustServerCertificate=True;"
            };

            ServiceCollection.RegisterDataBaseDependencies(regParams);
            ServiceCollection.RegisterJournal();

            AdjustEnvironment(ServiceCollection);

            Services = ServiceCollection.BuildServiceProvider();
        }

        public T GetService<T>()
        {
            return Services.GetRequiredService<T>();
        }
    }
}
