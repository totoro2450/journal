using Journal.Database.Registration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ContextRegistrationParams = Journal.Database.Registration.Dependencies.ContextRegistrationParams;

namespace Journal.Database.Data.Environment.Base
{
    public class EnvironmentBase
    {
        protected readonly IServiceCollection ServiceCollection = new ServiceCollection();
        protected ServiceProvider Services;

        public EnvironmentBase()
        {
            Services = ServiceCollection.BuildServiceProvider();
            RegisterServices();
        }

        public virtual void AdjustEnvironment(IServiceCollection services)
        {
        }

        public void RegisterServices()
        {
            ServiceCollection.AddSingleton<ILoggerFactory, LoggerFactory>();
            ServiceCollection.AddSingleton(typeof(ILogger<>), typeof(Logger<>));

            var regParams = new ContextRegistrationParams
            {
                InMemoryServer = false,
                ConnectionString = @$"Server=(local);Database={DatabaseConstants.DatabaseName};Trusted_Connection=True;TrustServerCertificate=True;"
            };

            ServiceCollection.RegisterDataBaseDependencies(regParams);

            AdjustEnvironment(ServiceCollection);

            Services = ServiceCollection.BuildServiceProvider();
        }

        public T GetService<T>() where T : notnull
        {
            return Services.GetRequiredService<T>();
        }
    }
}
